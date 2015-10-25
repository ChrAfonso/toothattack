using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	float t = 0;

	void Start()
	{
		t = 0;
	}

	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (Input.anyKeyDown && t > 5)
		{
			//Application.LoadLevel("dentist");
			Application.LoadLevel("TitleScreen");
		}
	}
}
