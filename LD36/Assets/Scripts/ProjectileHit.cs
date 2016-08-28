using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

	public string fabricEvent;
	bool hit;
	void OnCollisionEnter(Collision col) {
		if (!hit) {
			Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);
			hit = true;
		}
	}
}
