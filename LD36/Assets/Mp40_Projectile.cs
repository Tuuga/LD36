using UnityEngine;
using System.Collections;

public class Mp40_Projectile : MonoBehaviour {

	public string fabricEvent;

	void Start () {
		Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);
	}
}
