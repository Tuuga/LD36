using UnityEngine;
using System.Collections;

public class Bow_Shooting : MonoBehaviour {

	public GameObject projectile;
	public float force;
	public float upForce;
	public float maxDrawTime;
	public float minDrawTime;
    public string fabricEventShoot;
	public string fabricEventDraw;

	float drawTimer;

	GameObject mainCam;
	Transform shootPos;

	bool startDraw;

	void Start () {
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		shootPos = GameObject.Find("Shoot Point").transform;
	}

	void Update () {
		if (Input.GetButton("Fire1") && transform.parent.tag == "Player") {
			drawTimer += Time.deltaTime;
			drawTimer = Mathf.Clamp(drawTimer, 0, maxDrawTime);
			if (!startDraw) {
				Fabric.EventManager.Instance.PostEvent(fabricEventDraw, gameObject);
				startDraw = true;
			}
        }
		if (Input.GetButtonUp("Fire1") && drawTimer > minDrawTime) {
			Shoot();
			drawTimer = 0;
			startDraw = false;
		}
	}

	void Shoot () {
        Fabric.EventManager.Instance.PostEvent(fabricEventShoot, gameObject);
        GameObject projIns = (GameObject)Instantiate(projectile, shootPos.position, mainCam.transform.rotation);
		var rb = projIns.GetComponent<Rigidbody>();
		rb.velocity = (mainCam.transform.forward + Vector3.up * upForce).normalized * force * drawTimer;
	}
}
