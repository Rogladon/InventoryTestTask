using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : InteractiveObject {

	[SerializeField]
	private GameObject point;
	[SerializeField]
	private Vector3 offsetFromMousePosition;

	
	private void Update() {
		if (used) {
			rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
			transform.position = InputHelper.mousePosition + offsetFromMousePosition;
		}
	}
	public override void MouseDown(bool b) {
		HoverOut();
		if (!b && isUsable) {
			used = true;
			foreach (var i in GetComponentsInChildren<Collider>())
				i.gameObject.layer = 2;
		}
	}

	public override void MouseEnter(bool b) {
		if(!b && isUsable) {
			Hover();
		}
	}

	public override void MouseExit(bool b) {
		HoverOut();
	}

	public override void MouseUp(bool b, InteractiveObject obj = null) {
		used = false;
		foreach (var i in GetComponentsInChildren<Collider>())
			i.gameObject.layer = 0;
	}

	void Hover() {
		point.SetActive(true);
	}
	void HoverOut() {
		point.SetActive(false);
	}
}
