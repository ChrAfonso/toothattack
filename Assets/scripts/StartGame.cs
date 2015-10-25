using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	float t = 0;
	// Use this for initialization
	void Start () {
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (Input.anyKeyDown && t > 0.5)
		{
			Application.LoadLevel("dentist");
		}
	}
}
