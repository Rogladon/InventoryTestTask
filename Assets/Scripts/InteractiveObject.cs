using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractiveObject : MonoBehaviour
{
    public bool used { get; protected set; }
	public bool isUsable { get; protected set; } = true;
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
	public void AddInContainer(Container container, Transform domain) {
		config.container = container;
		Usable(false);
		OffRigidbody();
		transform.SetParent(domain);
		SwipeObject swipeObject = gameObject.AddComponent<SwipeObject>();
		swipeObject.Init(domain.position, domain.rotation, 0.5f);
	}
	public void PopFromContainer(Container container, Transform domain) {
		config.container = null;
		transform.parent = null;
		Usable(true);
		OnRigidbody();
		GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), 1, -2) * 100);
	}
}
