using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	GameObject character;

	// Use this for initialization
	void Start () {
		character = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, transform.position.z);
	}
}
