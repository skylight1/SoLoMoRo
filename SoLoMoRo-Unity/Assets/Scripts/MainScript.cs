using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PubNubMessaging.Core;

public class MainScript : MonoBehaviour {

	/*

Publish key: pub-c-b1dcebb2-3cea-42b5-bd20-e4139b976227
Subscribe Key: sub-c-b8998a32-382a-11e7-9361-0619f8945a4f
Secret: sec-c-Njg2OTgxMDEtYjYyYy00MGY4LTg0MzItODZmNzQxOGVkMzUy

	*/
	Pubnub pubnub;

	GameObject tracker1;
	GameObject tracker2;
	Transform track1Trans;
	Transform track2Trans;

	void DisplayReturnMessage(string result)
	{
		//UnityEngine.Debug.Log("PUBLISH STATUS CALLBACK");
		//UnityEngine.Debug.Log(result);
	}
	void DisplayErrorMessage(PubnubClientError pubnubError) {
		UnityEngine.Debug.Log(pubnubError.StatusCode);
	}

	// Use this for initialization
	void Start () {

		UnityEngine.VR.VRSettings.showDeviceView = false;

		pubnub = new Pubnub( "pub-c-b1dcebb2-3cea-42b5-bd20-e4139b976227", "sub-c-b8998a32-382a-11e7-9361-0619f8945a4f");

		InvokeRepeating("Publish", 2.0f, 0.5f);

		tracker1 = GameObject.Find ("Tracker1");
		track1Trans = tracker1.transform.FindChild ("OpenVRRenderModel");
		tracker2 = GameObject.Find ("Tracker2");
		track2Trans = tracker2.transform.FindChild ("OpenVRRenderModel");
	}

	void Publish() {
		float distance = 0.0f;

		if (tracker1 != null) {
			
		} else {
			UnityEngine.Debug.Log ("tracker1 null");
		}
		if (tracker2 != null) {

		} else {
			UnityEngine.Debug.Log ("tracker2 null");
		}

		distance = Vector3.Distance (track1Trans.position, track2Trans.position);

		UnityEngine.Debug.Log ("distance="+distance.ToString());

		pubnub.Publish<string>(
			"distance",
			distance.ToString(),
			DisplayReturnMessage,
			DisplayErrorMessage
		);

	}


	// Update is called once per frame
	void Update () {
		
	}
}
