using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractiveObject : MonoBehaviour
{
    public bool used { get; protected set; }
	public bool isUsable { get; protected set; } = true;
	[Header("ConfigObject")]
	[SerializeField]
	public ConfigObject config;

	private void Start() {
		config.obj = this;
	}

	public abstract void MouseEnter(bool b);
	public abstract void MouseExit(bool b);
	public abstract void MouseDown(bool b);
	public abstract void MouseUp(bool b, InteractiveObject obj = null);

	public void Usable(bool b) {
		isUsable = b;
	}
	public void OnRigidbody() {
		Rigidbody rigid;
		if (TryGetComponent(out rigid)) {
			rigid.isKinematic = false;
		}
	}
	public void OffRigidbody() {
		Rigidbody rigid;
		if (TryGetComponent(out rigid)) {
			rigid.isKinematic = true;
		}
	}
}
