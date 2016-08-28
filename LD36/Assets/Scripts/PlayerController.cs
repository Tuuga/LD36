using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	public float movSpeed;
	public float sprintSpeed;
	public float crouchSpeed;
	public float mouseSens;
	public float upDownRange;

	float verticalRotation;
	float horizontalRotation;
	float starMovSpeed;

	bool mouseLock;

	GameObject mainCam;

	Quaternion baseRotation = Quaternion.identity;
	CapsuleCollider cc;
	void Start () {
		cc = GetComponent<CapsuleCollider>();
		starMovSpeed = movSpeed;
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

		if (Input.GetButtonDown("Jump")) {
			Jump();
		}

		// Sprint if Shift and running forward or forward diagonally
		if (Input.GetButton("Sprint") && Vector3.Dot(transform.forward, moveDir) > 0) {
			movSpeed = sprintSpeed;
		}

		if(Input.GetButton("Crouch")) {
			Crouch();
		}
		if(Input.GetButtonUp("Crouch")) {
			Stand();
		}

		transform.position += moveDir * movSpeed * Time.deltaTime;
		movSpeed = starMovSpeed;
	}

	void Jump () {

	}

	void Crouch () {
		movSpeed = crouchSpeed;
		cc.height = 1;
		cc.center = Vector3.zero;
		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
	}

	void Stand () {
		cc.height = 2;
		cc.center = new Vector3(0, -0.5f, 0);
		transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
	}
}
