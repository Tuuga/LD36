using UnityEngine;
using System.Collections;

public class Mp40_Shooting : MonoBehaviour {
	public float fireRate;
	public float randAim;
	public LayerMask mask;

	public string fabricEvent;

	GameObject mainCam;
	float shootTimer;

	void Start() {
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update() {
		if (Input.GetButton("Fire1") && transform.parent.tag == "Player") {
			Shoot();
		}
	}

	void Shoot() {
		shootTimer += Time.deltaTime;
		if (shootTimer < fireRate)
			return;

		shootTimer = 0;

		Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);
		var dir = mainCam.transform.forward;
		float aimX = Random.Range(0, randAim);
		float aimY = Random.Range(0, randAim);
		Quaternion aimRot = Quaternion.Euler(aimX, aimY, 0);
		print("Dir: " + dir);
		dir = aimRot * dir;
		print("Dir Rand: " + dir);

		RaycastHit hit;
		if (Physics.Raycast(mainCam.transform.position, dir, out hit, mask.value)) {
			Debug.DrawLine(mainCam.transform.position, hit.point);
		}
	}
}
