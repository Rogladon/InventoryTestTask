using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : InteractiveObject {
	[SerializeField]
	private GameObject point;
	private List<InteractiveObject> items;
	
	Dictionary<ConfigObject.Type, Transform> domains {
		get {
			return _domains.dictionary;
		}
	}
	[SerializeField]
	TypeThingTransformDictionary _domains = TypeThingTransformDictionary.New<TypeThingTransformDictionary>();
	public override void MouseDown(bool b) {
		if (!b) {
			InventoryUI.events.openUI.Invoke(items);
		}
	}

	public override void MouseEnter(bool b) {
		if (b) {
			Hover();
		}
	}

	public override void MouseExit(bool b) {
		HoverOut();
	}

	public override void MouseUp(bool b, InteractiveObject obj = null) {
		if (b && obj) {
			AddObject(obj);
		} else {
			InventoryUI.events.closeUI.Invoke();
		}
	}

	void Hover() {
		point.SetActive(true);
	}
	void HoverOut() {
		point.SetActive(false);
	}
	public void AddObject(InteractiveObject obj) {
		if (obj == this) return;
		items.Add(obj);
		obj.config.container = this;
		obj.Usable(false);
		obj.OffRigidbody();
		SwipeObject swipeObject = obj.gameObject.AddComponent<SwipeObject>();
		swipeObject.Init(domains[obj.config.type].position, domains[obj.config.type].rotation, 0.5f);
	}

	public void PopObject(InteractiveObject obj) {
		if (obj == this) return;
		items.Remove(obj);
		obj.config.container = null;
		obj.Usable(true);
		obj.OnRigidbody();
		obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), 1, 2) * 100);
	}
}
