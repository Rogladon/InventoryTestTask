using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
	[SerializeField]
	private InteractiveObject _interactiveScript;
	public InteractiveObject interactiveScript {
		get {
			return _interactiveScript;
		}
	}
	private enum Type {
		thing,
		container
	}
	[Header("Config Object")]
	[SerializeField]
	private bool isUsable;
	[SerializeField]
	private Type type;


	[ContextMenu("Create")]
	public void Create() {
		
		InteractiveObject inter;
		if (!TryGetComponent(out inter)) {
			switch (type) {
				case Type.thing:
					inter = gameObject.AddComponent<Thing>();
					break;
				case Type.container:
					inter = gameObject.AddComponent<Container>();
					break;
			}
		}
		inter.Usable(isUsable);

		Rigidbody rigid;
		if (!gameObject.TryGetComponent(out rigid)) {
			rigid = gameObject.AddComponent<Rigidbody>();
		}
		rigid.useGravity = true;
		rigid.mass = inter.config.weight;

		_interactiveScript = inter;
		foreach (Transform i in transform) {
			SetCollider(i);
		}
		SetCollider(transform);
		Debug.Log("Create Interactive Object sucessful!");
	}
	void SetCollider(Transform i) {
		if (i.TryGetComponent(out Collider c)) {
			return;
		}
		MeshFilter meshFilter;
		if (i.TryGetComponent(out meshFilter)) {
			MeshCollider collider;
			if (!i.TryGetComponent(out collider)) {
				collider = i.gameObject.AddComponent<MeshCollider>();
			}
			collider.convex = true;
		}
		return;
	}
}
