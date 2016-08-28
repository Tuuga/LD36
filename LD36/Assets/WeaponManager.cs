using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	public List<GameObject> weapons;
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void SetWeaponActive (int index) {
		foreach (GameObject w in weapons) {
			w.SetActive(false);
		}
		weapons[index].SetActive(true);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			SetWeaponActive(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			SetWeaponActive(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			SetWeaponActive(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			SetWeaponActive(3);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			SetWeaponActive(4);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			SetWeaponActive(5);
		}
	}
}
