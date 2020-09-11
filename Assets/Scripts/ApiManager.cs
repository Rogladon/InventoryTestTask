using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour {


	struct Request {
		public string type;
		public int id;
	}

	public class AddObjectInContainer : UnityEvent<int> { }
	public class PopObjectFromContainer : UnityEvent<int> { }

	public class Events {
		public AddObjectInContainer addObjectInContainer = new AddObjectInContainer();
		public PopObjectFromContainer popObjectFromContainer = new PopObjectFromContainer();
	}
	public static Events events = new Events();

	void Start() {
		InitializeEvents();
	}

	void InitializeEvents() {
		events.addObjectInContainer.AddListener((int id) => {
			StartCoroutine(POST(id, "AddObject"));
		});
		events.addObjectInContainer.AddListener((int id) => {
			StartCoroutine(POST(id, "RemoveObject"));
		});
	}

	IEnumerator POST(int id, string typeEvent) {
		List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
		formData.Add(new MultipartFormDataSection("auth", "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6"));
		formData.Add(new MultipartFormDataSection("typeEvent", typeEvent));
		formData.Add(new MultipartFormDataSection("id", id.ToString()));

		string sentData = JsonUtility.ToJson(new Request { type = typeEvent, id = id });

		var request = new UnityWebRequest("https://dev3r02.elysium.today/inventory/status", UnityWebRequest.kHttpVerbPOST) {
			uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(sentData))
		};
		request.SetRequestHeader("auth", "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6");
		yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError) {
			Debug.Log(request.error);
		} else {
			Debug.Log("Form upload complete!");
		}
	}
}
