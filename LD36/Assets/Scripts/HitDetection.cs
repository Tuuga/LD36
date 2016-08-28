using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

	public enum ColliderType { Head, Body };
	public ColliderType ownType;

	TargetController tc;
	void Start () {
		tc = transform.GetComponentInParent<TargetController>();
	}

	void OnCollisionEnter(Collision c) {
		if (ownType == ColliderType.Head) {
			tc.Hit(true);
		} else {
			tc.Hit(false);
		}
	}
}
