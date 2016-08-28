using UnityEngine;
using System.Collections;

public class Rock_Shooting : MonoBehaviour {

	public GameObject projectile;
	public float force;
	public float upForce;
    public string fabricEvent;

	GameObject mainCam;
	Transform shootPos;

	void Start () {
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		shootPos = GameObject.Find("Shoot Point").transform;
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && transform.parent.tag == "Player") {
			Shoot();
        }
	}

	void Shoot () {
        Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);

		var randomRot = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        GameObject projIns = (GameObject)Instantiate(projectile, shootPos.position, randomRot);
		var rb = projIns.GetComponent<Rigidbody>();
		rb.velocity = (mainCam.transform.forward + Vector3.up * upForce).normalized * force;
	}
}
