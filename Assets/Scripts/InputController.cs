using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	bool used {
		get {
			return usedObject;
		}
		set {
			usedObject = null;
		}
	}
	Interactive interactive;
	InteractiveObject usedObject;
    void LateUpdate()
    {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit)) {
			if (interactive) {
				if (hit.transform != interactive.transform) {
					interactive.interactiveScript.MouseExit(used);
				}
			}
			if (hit.transform.TryGetComponent(out interactive)) {
				interactive.interactiveScript.MouseEnter(used);
			}
		} else {
			if (interactive) {
				interactive.interactiveScript.MouseExit(used);
			}
			interactive = null;
		}
		if (InputHelper.lkmDown && interactive) {
			interactive.interactiveScript.MouseDown(used);
			if (interactive.interactiveScript.isUsable) {
				usedObject = interactive.interactiveScript;
			}
		}
		if (InputHelper.lkmUp && used) {
			if (interactive) {
				interactive.interactiveScript.MouseUp(used, usedObject);
			}
			usedObject.MouseUp(used);
			used = false;
		}
	}
}
