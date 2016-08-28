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
		if (!head) {
			print("HeadShot");
			tc.Hit(true);
		} else if (head) {
			print("BodyShot");
			tc.Hit(false);
		}
	}

	public void SetHit (bool b) {
		hitHead = b;
		print(name + " " + hitHead);
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Projectile") {
			GetComponentInParent<HitDetection>().SetHit(head);
		}
	}

	void OnCollisionEnter(Collision c) {
		if (c.transform.tag == "Projectile" && name == "Target Parts") {
			GotHit();
		}
	}
}
