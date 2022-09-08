using UnityEngine;
using System.Collections;

public class TeleportsMap2 : MonoBehaviour {

	private float x,y,z;
	public static int cubeFace;

	public static bool entro;

	GameObject pacman;
	public GameObject camera;
	public GameObject lightDir;

	void getCoordinates() {
		x = GameObject.Find("Pacman").GetComponent<Player>().transform.position.x;
		y = GameObject.Find("Pacman").GetComponent<Player>().transform.position.y;
		z = GameObject.Find("Pacman").GetComponent<Player>().transform.position.z;
	}

	void detectFace() {
		if(y > 20 && y <= 21) {	// TOP
			cubeFace = 1;
		}
	}

	void detectTeleport() {
		Vector3 trans;
		Vector3 rot;
		switch(cubeFace) {
			case 1: // UP
				if(x > -0.7 && x <= -0.3 && z <= -5 && z > -5.5) {	// FRONT
					trans = new Vector3(-0.53f, 18.9f, -6.4f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 2;
					rot = new Vector3(0.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(-0.2f, 17.0f, -14.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(-270, 0, 0);
				} else if(x > 4 && x <= 4.5 && z > -0.7 && z <= -0.3) {	// RIGHT
					trans = new Vector3(5.4f, 18.9f, -0.5f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 4;
				rot = new Vector3(50.0f, 270.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 270.0f, 0.0f);
					camera.transform.position = new Vector3(12.8f, 17.0f, -0.4f);
					//camera.transform.position = new Vector3(-15f, 17.0f, -0.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;	
					pacman.transform.localEulerAngles = new Vector3(90, 90, 0);
				} else if(z > -0.7 && z < -0.3 && x > -5.5 && x <= -5) {	// LEFT
					trans = new Vector3(-6.5f, 18.9f, -0.5f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 3;
				rot = new Vector3(50.0f, 90.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 90.0f, 0.0f);
					camera.transform.position = new Vector3(-14.3f, 17.0f, -0.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(90, 90, 0);
				} else if(z >= 4 && z < 4.5 && x > -0.7 && x < 0.3) {	// BACK
					trans = new Vector3(-0.53f, 18.5f, 5.4f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 5;
				rot = new Vector3(50.0f, 180.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 180.0f, 0.0f);
					camera.transform.position = new Vector3(-0.2f, 17.0f, 13.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(90, 90, 90);
				} 
				break;
			case 2:	// FRONT
				if(x > -0.7 && x <= -0.3 && y >= 19.1 && y < 19.5) {	// UP
					trans = new Vector3(-0.53f, 20.35f, -4.9f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 1;
				rot = new Vector3(50.0f, 0.0f, 0.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(40.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(-0.45f, 24.0f, -8.66f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 0, 0);

				} else if(x > -6.0 && x <= -5.0 && y > 14.3 && y < 14.7) { // LEFT
					trans = new Vector3(-6.5f, 14.5f, -4.9f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 3;
				rot = new Vector3(50.0f, 90.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 90.0f, 0.0f);
					camera.transform.position = new Vector3(-15f, 12.8f, -4.8f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
				pacman.transform.localEulerAngles = new Vector3(0, 0, 90);
				} else if(x >= 4.0 && x < 5.0 && y > 14.3 && y < 14.7) {	// RIGHT
					trans = new Vector3(5.4f, 14.5f, -4.9f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 4;
				rot = new Vector3(50.0f, 270.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 270.0f, 0.0f);
					camera.transform.position = new Vector3(12.8f, 12.8f, -4.8f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 0, 90);
				}
				break;
			case 3:	// LEFT
				if(y >= 19 && y < 19.5 && z > -0.7 && z < -0.2) {	// UP
					trans = new Vector3(-4.9f, 20.35f, -0.5f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 1;
				rot = new Vector3(50.0f, 0.0f, 0.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(40.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(-4.82f, 24.0f, -4.26f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 90, 0);

				}
				if(y > 14.2 && y < 14.7 && z > -5.7 && z <= -5) {	// FRONT
					trans = new Vector3(-4.9f, 14.5f, -6.4f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 2;
				rot = new Vector3(50.0f, 0.0f, 0.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(-4.57f, 12.8f, -14.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, -270, -90);
			} else if(z >= 4.0 && z < 4.5 && y > 14.2 && y < 14.7) {	// BACK
				trans = new Vector3(-4.9f, 14.5f, 5.4f);
				pacman.GetComponent<Player>().transform.position = trans;
				cubeFace = 5;
				rot = new Vector3(50.0f, 180.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
				rot = new Vector3(0.0f, 180.0f, 0.0f);
				camera.transform.position = new Vector3(-4.57f, 12.8f, 13.4f);
				camera.transform.eulerAngles = rot;
				CameraMovement.offset = camera.transform.position - pacman.transform.position;
				pacman.transform.localEulerAngles = new Vector3(0, -270, -90);
			}
				break;
			case 4:	// RIGHT
				if(z >= -0.7 && z < -0.2 && y >= 19 && y < 19.7) {	// UP
					trans = new Vector3(3.9f, 20.35f, -0.5f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 1;
				rot = new Vector3(50.0f, 0.0f, 0.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(40.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(3.98f, 24.0f, -4.26f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 270, 0);

				} else if(z <= -5.0 && z > -5.5 && y > 14.2 && y < 14.7) {	// FRONT
					trans = new Vector3(3.9f, 14.5f, -6.4f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 2;
				rot = new Vector3(50.0f, 0.0f, 0.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(4.23f, 12.8f, -14.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, -90, 90);
				} else if(z >= 4.0 && z < 5.0 && y > 14.2 && y < 14.7) {	// BACK
					trans = new Vector3(3.9f, 14.5f, 5.36f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 5;
				rot = new Vector3(50.0f, 180.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 180.0f, 0.0f);
					camera.transform.position = new Vector3(4.13f, 12.8f, 13.4f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, -90, 90);
				}
				break;
			case 5:	// BACK
				if(y >= 19.0 && y < 19.7 && x < -0.3 && x > -0.7) {	// UP
					trans = new Vector3(-0.53f, 20.35f, 3.0f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 1;
				rot = new Vector3(50.0f, 0.0f, 0.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(40.0f, 0.0f, 0.0f);
					camera.transform.position = new Vector3(-0.45f, 24.0f, 0.14f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 180, 0);
				} else if(x >=4.0 && x < 4.5 && y > 14.2 && y < 14.7) {	// RIGHT
					trans = new Vector3(5.4f, 14.5f, 3.9f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 4;	
				rot = new Vector3(50.0f, 270.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 270.0f, 0.0f);
					camera.transform.position = new Vector3(12.8f, 12.8f, 4.0f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 180, 270);
				} else if(x <= -5.0 && x > -5.5 && y > 14.2 && y < 14.7) {	// LEFT
					trans = new Vector3(-6.5f, 14.5f, 3.9f);
					pacman.GetComponent<Player>().transform.position = trans;
					cubeFace = 3;
				rot = new Vector3(50.0f, 90.0f, 10.0f);
				lightDir.transform.eulerAngles = rot;
					rot = new Vector3(0.0f, 90.0f, 0.0f);
					camera.transform.position = new Vector3(-14.3f, 12.8f, 4.0f);
					camera.transform.eulerAngles = rot;
					CameraMovement.offset = camera.transform.position - pacman.transform.position;
					pacman.transform.localEulerAngles = new Vector3(0, 180, 270);
				}
				break;
		}	
	}

	// Use this for initialization
	void Start () {
		entro = false;
		pacman = GameObject.Find("Pacman");
	}

	// Update is called once per frame
	void Update () {
		getCoordinates();
		detectFace();
		detectTeleport();
	}
}
