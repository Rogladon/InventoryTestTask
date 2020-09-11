using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHelper : MonoBehaviour
{
    public static bool lkmDown {
		get {
			return Input.GetMouseButtonDown(0);
		}
	}
	public static bool lkmUp {
		get {
			return Input.GetMouseButtonUp(0);
		}
	}
	static Vector3 _mousePos;
	public static Vector3 mousePosition {
		get {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, (1<<8))) {
				Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
				_mousePos = hit.point;
				return hit.point;
			}
			return _mousePos;
		}
	}
}
