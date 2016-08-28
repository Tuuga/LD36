using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

	public string fabricEvent;
	public bool destroyOnHit;
	bool hit;

	void OnCollisionEnter(Collision col) {
		if (!hit && fabricEvent != "") {
			Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);
			hit = true;
		}
		if (destroyOnHit) {
			Destroy(gameObject);
		}
	}
}
