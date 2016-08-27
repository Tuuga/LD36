using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

	public enum ColliderType { Head, Body };
	public ColliderType ownType;

	TargetCollision tc;
	void Start () {
		tc = transform.GetComponentInParent<TargetCollision>();
	}

	void OnCollisionEnter(Collision c) {
		if (ownType == ColliderType.Head) {
			tc.Hit(true);
		} else {
			tc.Hit(false);
		}
	}
}
