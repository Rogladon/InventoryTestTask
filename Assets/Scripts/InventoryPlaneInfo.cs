using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlaneInfo : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private GameObject plane;
	[SerializeField]
	private Text nameItem;
	[SerializeField]
	private Text weight;
	[SerializeField]
	private Text type;
	public void Open(ConfigObject config) {
		plane.SetActive(true);
		nameItem.text = config.name;
		weight.text = config.weight.ToString();
		type.text = config.type.ToString();
	}

	public void Close() {
		plane.SetActive(false);
	}
}
