using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
	public class OpenUI : UnityEvent<List<InteractiveObject>> { }
	public class CloseUI : UnityEvent { }

    public class Events {
		public OpenUI openUI = new OpenUI();
		public CloseUI closeUI = new CloseUI();
	}

	public static Events events { get; } = new Events();
	[Header("Prefabs")]
	[SerializeField]
	private InventoryItem itemPrefab;

	[Header("Components")]
	[SerializeField]
	private Transform content;
	[SerializeField]
	private InventoryPlaneInfo planeInfo;
	[SerializeField]
	private GameObject planeItems;

	[Header("Other")]
	private List<InventoryItem> objectItems = new List<InventoryItem>();
	private void Start() {
		InitializeEvents();
	}

	private void InitializeEvents() {
		events.openUI.AddListener((List<InteractiveObject> items) => {
			planeItems.SetActive(true);
			foreach(var i in objectItems) {
				Destroy(i.gameObject);
			}
			objectItems.Clear();
			planeItems.SetActive(true);
			foreach(var i in items) {
				var go = Instantiate(itemPrefab, content).GetComponent<InventoryItem>();
				go.Init(i.config, planeInfo);
				objectItems.Add(go);
			}
		});
		events.closeUI.AddListener(() => {
			planeItems.SetActive(false);
			planeInfo.Close();
		});
	}
}
