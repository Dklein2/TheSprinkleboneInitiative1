﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class followPath : MonoBehaviour 
{
	public enum FollowType
	{
		MoveTowards,
		Lerp
	}
	public FollowType Type = FollowType.MoveTowards;
	public pathDefinition Path;
	public float Speed =1;
	public float MaxDistanceToGoal = .1f;

	private IEnumerator<Transform> _currentPoint;

	public void Start()
	{
		if (Path == null)
		{
			Debug.LogError("Path cannot be null", gameObject);
			return;
		}

		_currentPoint = Path.GetPathsEnumerator();
		_currentPoint.MoveNext();

		if(_currentPoint.Current ==null)
		{
			return;
		}

		transform.position = _currentPoint.Current.position;
	}

	public void Update()
	{
		if (_currentPoint == null || _currentPoint.Current == null)
		{
			return;
		}

		if(Type == FollowType.MoveTowards)
		{
			transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime*Speed);
		}
		else if (Type == FollowType.Lerp)
		{
			transform.position = Vector3.Lerp(transform.position,_currentPoint.Current.position, Time.deltaTime *Speed);
		}


		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
		{
			_currentPoint.MoveNext();
		
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.parent = transform;
			Debug.Log ("Player is child");
		}
		else
		{
			Debug.Log("error");
		}
	}
	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.parent = null;
			Debug.Log("player is not child");
		}
	}

}
