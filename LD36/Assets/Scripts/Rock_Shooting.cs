﻿using UnityEngine;
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
        GameObject projIns = (GameObject)Instantiate(projectile, shootPos.position, mainCam.transform.rotation);
		var rb = projIns.GetComponent<Rigidbody>();
		rb.velocity = (mainCam.transform.forward + Vector3.up * upForce).normalized * force;
	}
}
