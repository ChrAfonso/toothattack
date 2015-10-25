using UnityEngine;
using System.Collections;

public class JawMover : MonoBehaviour {

	GameObject UpperJaw;
	GameObject LowerJaw;

	float t = 0;

	// Use this for initialization
	void Start () {
		UpperJaw = GameObject.Find("UpperJaw");
		LowerJaw = GameObject.Find("LowerJaw");

		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		UpperJaw.transform.position = new Vector3(0, Mathf.Min(0, Mathf.Sin(t)*1.5f), 0);
		t += Time.deltaTime;
	}
}
