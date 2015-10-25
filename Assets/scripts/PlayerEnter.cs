using UnityEngine;
using System.Collections;

public class PlayerEnter : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log("trigger enter!");

		if (other.gameObject.tag == "Player")
		{
			Application.LoadLevel("Win");
		}
	}
}
