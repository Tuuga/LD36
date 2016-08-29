using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	public int weaponIndex;

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.transform.Find("WeaponManger").GetComponent<WeaponManager>().SetWeaponAvailable(weaponIndex);
			Destroy(gameObject);
		}
	}
}
