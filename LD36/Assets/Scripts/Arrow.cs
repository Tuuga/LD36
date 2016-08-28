using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	bool hit;

	Transform _attachedTo;
	Vector3 _attachPos;
	Quaternion _attachRot;
	Quaternion _ownRot;
	Vector3 _attachDir;

	void OnCollisionEnter(Collision c) {
		var rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		hit = true;
		Attach(c.transform);
	}

	void Attach(Transform t) {
		_attachedTo = t;
		_attachPos = t.position;
		_attachRot = t.rotation;
		_ownRot = Quaternion.Inverse(_attachRot) * transform.rotation;
		Vector3 _attachDifference = transform.position - t.position;
		_attachDir = Quaternion.Inverse(_attachRot) * _attachDifference;
	}
	void StayAttached() {
		if (_attachedTo.rotation != _attachRot) {
			_attachRot = _attachedTo.rotation;
		}

		if (_attachedTo.position != _attachPos)
			_attachPos = _attachedTo.position;

		transform.position = _attachPos + _attachRot * _attachDir;
		transform.rotation = _attachRot * _ownRot;
	}

	void LateUpdate() {
		if (hit) {
			StayAttached();
		}
	}
}
