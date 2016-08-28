using UnityEngine;
using System.Collections;

public class TargetController: MonoBehaviour {

	public float speed;
	public int headHP;
	public int bodyHP;

	int timesShotHead;
	int timesShotBody;

	Vector3 pointA;
	Vector3 pointB;
	Vector3 nextPoint;

	bool activated;
	bool alive = true;

	Transform targetParts;


	Animator anim;
	void Start () {
        targetParts = transform.Find("Target Parts");
        pointA = targetParts.position;
		pointB = transform.Find("Point B").position;
		anim = targetParts.GetComponent<Animator>();

		nextPoint = transform.position;
	}
	
	void Update () {

		if (Vector3.Distance(nextPoint, targetParts.position) > 0.1f) {
			Vector3 dir = (nextPoint - targetParts.position).normalized;
			targetParts.position += dir * speed * Time.deltaTime;
		}
	}

	void Activate () {
		nextPoint = pointB;
		activated = true;
	}

	void Deactivate () {
		nextPoint = pointA;
		activated = false;
	}

	public void Die () {
		Deactivate();
		alive = false;
	}

	public void Hit(bool head) {
		if (head) {
			timesShotHead++;
		} else {
			timesShotBody++;
		}
		if (timesShotHead >= headHP || timesShotBody >= bodyHP) {
			Die();
		}
	}

	// Can only collide with player layer
	void OnTriggerEnter(Collider c) {
		if (!activated && alive) {
			Activate();
		}
	}

	void OnTriggerExit (Collider c) {
		if(activated && alive) {
			Deactivate();
		}
	}
}
