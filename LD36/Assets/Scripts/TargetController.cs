using UnityEngine;
using System.Collections;

public class TargetController: MonoBehaviour {

	public float speed;
	public string actAnim;
	string deactAnim;

	Vector3 pointA;
	Vector3 pointB;
	Vector3 nextPoint;

	bool activated;
	bool alive = true;

	Transform targetParts;

	Animator anim;
	void Start () {
		pointA = transform.position;
		pointB = transform.Find("Point B").position;
		targetParts = transform.Find("Target Parts");
		anim = targetParts.GetComponent<Animator>();
		deactAnim = actAnim + "R";
	}

	void Update () {
		if (Vector3.Distance(targetParts.position, pointA) < 0.2f) {
			nextPoint = pointB;
		} else if (Vector3.Distance(targetParts.position, pointB) < 0.2f) {
			nextPoint = pointA;
		}

		Vector3 dir = (nextPoint - targetParts.position).normalized;
		targetParts.position += dir * speed * Time.deltaTime;
	}

	void Activate () {
		activated = true;
		anim.Play(actAnim);
	}

	void Deactivate () {
		anim.Play(deactAnim);
		activated = false;
	}

	public void Die () {
		anim.Play(deactAnim);
		alive = false;
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
