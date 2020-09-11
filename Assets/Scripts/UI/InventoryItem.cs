using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	ConfigObject config;
	InventoryPlaneInfo planeInfo;
	bool pointerInObject = false;
    public void Init(ConfigObject _config, InventoryPlaneInfo _planeInfo) {
		config = _config;
		planeInfo = _planeInfo;
		GetComponentInChildren<Text>().text = config.name;
	}

	void Update() {
		if (pointerInObject) {
			if (InputHelper.lkmUp) {
				config.container.PopObject(config.obj);
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData) {
		planeInfo.Open(config);
		pointerInObject = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		planeInfo.Close();
		pointerInObject = false;
	}

}
