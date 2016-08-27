using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour {

	int timesShotHead;
	int timesShotBody;

	public int headHP;
	public int bodyHP;

	public void Hit(bool head) {
		if (head) {
			timesShotHead++;
		} else {
			timesShotBody++;
		}
		if (timesShotHead >= headHP || timesShotBody >= bodyHP) {
			GetComponent<TargetController>().Die();
		}
	}
}
