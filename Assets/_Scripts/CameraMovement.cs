using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject pacman;
	public static Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - pacman.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Player.deadmap2) {
			Player.deadmap2 = false;
			GameObject camera = GameObject.Find("MainCamera");
			camera.transform.position = new Vector3(-0.45f, 24.0f, -7.0f);
			camera.transform.eulerAngles = new Vector3(40.0f, 0.0f, 0.0f);
			TeleportsMap2.cubeFace = 1;
			offset = transform.position - pacman.transform.position;
		}
		else transform.position = pacman.transform.position + offset;
	}
}
