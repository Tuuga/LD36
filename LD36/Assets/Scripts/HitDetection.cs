using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

	public enum ColliderType { Head, Body };
	public ColliderType ownType;

	TargetController tc;
	void Start () {
		tc = transform.GetComponentInParent<TargetController>();
	}

	public void GotHit () {
		if (ownType == ColliderType.Head) {
			tc.Hit(true);
		} else {
			tc.Hit(false);
		}
	}

	void OnCollisionEnter(Collision c) {
		GotHit();
	}
}
