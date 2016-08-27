using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour {

	public int timesShotHead;
	public int timesShotBody;

	public void Hit(bool head) {
		if (head) {
			timesShotHead++;
		} else {
			timesShotBody++;
		}
	}
}
