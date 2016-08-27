using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	public float movSpeed;
	public float mouseSens;
	public float upDownRange;

	float verticalRotation;
	float horizontalRotation;

	bool mouseLock;

	GameObject mainCam;

	Quaternion baseRotation = Quaternion.identity;

	void Start () {

		MouseLock();
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update () {

		Movement();

		if (mouseLock)
			MouseLook();

		if (Input.GetKeyDown(KeyCode.LeftAlt))
			MouseLock();
	}

	void MouseLook () {
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

		horizontalRotation += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

		transform.localRotation = Quaternion.Euler(0, horizontalRotation, 0) * baseRotation;
		mainCam.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0) * baseRotation;

		mainCam.transform.position = transform.position;

	}

	void MouseLock () {
		mouseLock = !mouseLock;
		if (mouseLock) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		} else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	void Movement () {
		Vector3 moveDir = new Vector3();
		moveDir += transform.forward * Input.GetAxis("Vertical");
		moveDir += transform.right * Input.GetAxis("Horizontal");

		moveDir.y = 0;

		transform.position += moveDir * movSpeed * Time.deltaTime;
	}
}
