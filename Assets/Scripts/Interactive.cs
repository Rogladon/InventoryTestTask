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
}
