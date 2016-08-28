using UnityEngine;
using System.Collections;

public class Lazer_Shooting : MonoBehaviour {

	public float reloadTime;
	public float recoil;
	public float force;
	public LayerMask mask;
	public GameObject projectile;

	public string fabricEvent;

	GameObject mainCam;
	float reloadTimer;

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

		Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);
		var dir = mainCam.transform.forward;
		float aimX = Random.Range(-recoil, recoil);
		float aimY = Random.Range(-recoil, recoil);
		Quaternion aimRot = Quaternion.Euler(aimX, aimY, 0);
		dir = aimRot * dir;

		GameObject projIns = (GameObject)Instantiate(projectile, shootPos.position, mainCam.transform.rotation);
		Destroy(projIns, 3f);
		var rb = projIns.GetComponent<Rigidbody>();
		rb.velocity = dir * force;

		RaycastHit hit;
		if (Physics.Raycast(mainCam.transform.position, dir, out hit, Mathf.Infinity, mask)) {
			if (hit.transform.tag == "Target") {
				if (hit.collider.name == "Head") {
					hit.transform.parent.GetComponent<HitDetection>().hitHead = true;
				} else if (hit.collider.name == "Body") {
					hit.transform.parent.GetComponent<HitDetection>().hitHead = false;
				}
				hit.transform.parent.GetComponent<HitDetection>().GotHit();
			}
			Debug.DrawLine(mainCam.transform.position, hit.point);
		}
	}
}
