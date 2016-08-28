using UnityEngine;
using System.Collections;

public class Crossbow_Shooting : MonoBehaviour {

	public GameObject projectile;
	public float force;
	public float upForce;
	public float reloadTime;
	public string fabricEventShoot;

	float reloadTimer;

	GameObject mainCam;
	Transform shootPos;

	void Start() {
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		shootPos = GameObject.Find("Shoot Point").transform;
	}

	void Update() {
		reloadTimer -= Time.deltaTime;
		if (Input.GetButtonDown("Fire1") && transform.parent.tag == "Player") {
			Shoot();
		}
	}

	void Shoot() {
		if (reloadTimer >= 0)
			return;

		reloadTimer = reloadTime;

		Fabric.EventManager.Instance.PostEvent(fabricEventShoot, gameObject);
		GameObject projIns = (GameObject)Instantiate(projectile, shootPos.position, mainCam.transform.rotation);
		var rb = projIns.GetComponent<Rigidbody>();
		rb.velocity = (mainCam.transform.forward + Vector3.up * upForce).normalized * force;
	}
}
