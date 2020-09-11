using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeObject : MonoBehaviour
{
	Vector3 targetPosition;
	Quaternion targetRotation;
	float tLerp;


	public void Init(Vector3 _targetPosition, float _tLerp) {
		Init(_targetPosition, transform.rotation, _tLerp);
	}
	public void Init(Quaternion _targetRotation, float _tLerp) {
		Init(transform.position, _targetRotation, _tLerp);
	}

	public void Init(Vector3 _targetPosition, Quaternion _targetRotation, float _tLerp) {
		targetRotation = _targetRotation;
		targetPosition = _targetPosition;
		tLerp = _tLerp;
	}

	private void Update() {
		Rigidbody rigid;
		if(TryGetComponent(out rigid)) {
			rigid.useGravity = false;
		}
		bool destroy = true;
		if(Vector3.Distance(transform.rotation.eulerAngles, targetRotation.eulerAngles) > 0.01f) {
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tLerp);
			destroy = false;
		} 
		if(Vector3.Distance(transform.position, targetPosition) > 0.01f) {
			transform.position = Vector3.Lerp(transform.position, targetPosition, tLerp);
			destroy = false;
		}
		if (destroy) {
			if (rigid) rigid.useGravity = true;
			Destroy(this);
		}
	}
}
