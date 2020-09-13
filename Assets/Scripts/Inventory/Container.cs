using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : InteractiveObject {
	[SerializeField]
	private GameObject point;
	private List<InteractiveObject> items = new List<InteractiveObject>();
	
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
		obj.AddInContainer(this, domains[obj.config.type]);
		ApiManager.events.addObjectInContainer.Invoke(obj.config.id);
	}

	public void PopObject(InteractiveObject obj) {
		if (obj == this) return;
		items.Remove(obj);
		obj.PopFromContainer(this, domains[obj.config.type]);
		ApiManager.events.popObjectFromContainer.Invoke(obj.config.id);
	}
}
