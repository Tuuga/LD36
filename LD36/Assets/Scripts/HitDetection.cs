using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

	public enum ColliderType { None ,Head, Body };
	public bool head;
	public bool hitHead;

	TargetController tc;
	void Start () {
		tc = transform.GetComponentInParent<TargetController>();
	}

	public void GotHit () {
		if (hitHead) {
			print("HeadShot");
			tc.Hit(true);
		} else {
			//print("BodyShot");
			tc.Hit(false);
		}
	}

	public void SetHit (bool b) {
		hitHead = b;
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Projectile") {
			transform.parent.GetComponent<HitDetection>().hitHead = head;
		}
	}

	void OnCollisionEnter(Collision c) {
		if (c.transform.tag == "Projectile" && name == "Target Parts") {
			GotHit();
		}
	}
}
