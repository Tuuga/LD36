using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {

	public float speed;

	Vector3 pointA;
	Vector3 pointB;
	Vector3 nextPoint;

	void Start () {
		pointA = transform.position;
		pointB = transform.Find("Point B").position;
	}

	void Update () {
		
		if (Vector3.Distance(transform.position, pointA) < 0.2f) {
			nextPoint = pointB;
		} else if (Vector3.Distance(transform.position, pointB) < 0.2f) {
			nextPoint = pointA;
		}

		Vector3 dir = (nextPoint - transform.position).normalized;
		transform.position += dir * speed * Time.deltaTime;
	}
}
