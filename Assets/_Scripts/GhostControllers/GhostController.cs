using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class GhostController : MonoBehaviour {

	public Transform[] waypoints;
	Transform[] returnRute;
	public Vector3 initialPosition;
	int current = 1;

	int startTime;

	public float pauseDelay = 0;

	public bool isAgentStopped = false;
	public int equalCoordenate = 2;

	public bool isFirstPoint = true;

	public float lastAngle = 0;

	public float speed = 0.3f;

	public bool isDeath = false;

	public bool isRunningAway = false;

	private Animator scaredAnimator;

	GameObject ScaredGhost;

	GameObject NormalGhost;
	NavMeshAgent agent;

	Color lastColor;
	Color basicColor;

	Quaternion initialRotation;

	private int timeBlink;

	void Start() {
		ScaredGhost = this.transform.GetChild (1).gameObject;
		NormalGhost = this.transform.GetChild (0).gameObject;
		scaredAnimator = ScaredGhost.GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent> ();
		agent.Stop ();
		agent.destination = waypoints [current].position;
		isAgentStopped = true;
		initialPosition = transform.position;
		initialRotation = transform.rotation;
		basicColor = ScaredGhost.transform.Find ("Cylinder").GetComponent<Renderer> ().material.color;
		lastColor = Color.black;
		timeBlink = 0;
	}


	void Update() {

		if (Player.move && !Player.isDeath) {

			if (isAgentStopped) {
				agent.Resume ();
				isAgentStopped = false;
			}

			if (pauseDelay == 0) {

				Vector3 actualPosition = transform.position;
				float dist = agent.remainingDistance;
				if (dist <= 5) {
					if (isRunningAway) {
						current = (current - 1);
						if (current < 0) {
							current = 0;
							toNormalState ();
							if (isDeath)
								isDeath = false;
							toNormalState ();
						}
					} else {
						current = (current + 1) % waypoints.Length;
						if (current == 0)
							++current;


					}

					agent.destination = waypoints [current].position;

				
				}
			
			} else {
				--pauseDelay;
				if (pauseDelay == 0) {
					Time.timeScale = 1;
					agent.Resume ();
				}
			}
		}

		if (Player.isDeath && !isAgentStopped) {
			agent.Stop ();
			isAgentStopped = true;
		} 
	}


	public void setRunningAway() {
		isRunningAway = true;
		isFirstPoint = true;
		if (current > 0) --current;
		agent.destination = waypoints [current].position;
		NormalGhost.SetActive (false);
		ScaredGhost.SetActive (true);
		scaredAnimator.SetBool ("isScared", true);
		//Speed, angular and aceleration modifications
		agent.speed = 30;
		agent.angularSpeed = 180;
		agent.acceleration = 50;
		
	}


	//Pacman death
	public void returnToInitialPosition() {
		agent.Warp (initialPosition);
		transform.rotation = initialRotation;
	}

	public bool getIsRunningAway() {
		return isRunningAway;
	}


	//Eyes ony mode
	public void isDeathTime() {

		ScaredGhost.transform.Find("Cylinder").gameObject.SetActive(false);
		ScaredGhost.transform.Find ("Plane").gameObject.SetActive (false);
		//Speed, angular and aceleration modifications
		agent.speed = 80;
		agent.angularSpeed = 360;
		agent.acceleration = 400;
		isDeath = true;
		Time.timeScale = 0;
		pauseDelay = 10;
		agent.Stop ();
		agent.destination = waypoints[0].position;

	}


	public void toNormalState() {

		ScaredGhost.transform.Find ("Cylinder").gameObject.GetComponent<Renderer> ().material.color = basicColor;
		isRunningAway = false;
		scaredAnimator.SetBool ("isScared", false);
		ScaredGhost.SetActive (false);
		NormalGhost.SetActive (true);
		//Speed, angular and aceleration modifications
		//Speed, angular and aceleration modifications
		agent.speed = 60;
		agent.angularSpeed = 360;
		agent.acceleration = 250;

		if (!ScaredGhost.transform.Find ("Cylinder").gameObject.activeSelf) {
			ScaredGhost.transform.Find ("Cylinder").gameObject.SetActive (true);
			ScaredGhost.transform.Find ("Plane").gameObject.SetActive (false);
		}

		timeBlink = 0;
		isDeath = false;
		lastColor = Color.black;
	}



	public void Blink() {
		if (timeBlink == 0) {
			Renderer renderer = ScaredGhost.transform.Find ("Cylinder").gameObject.GetComponent<Renderer> ();
			if (lastColor == Color.black) {
				lastColor = renderer.material.color;
				ScaredGhost.transform.Find ("Cylinder").gameObject.GetComponent<Renderer> ().material.color = basicColor;
			} else {
				if (lastColor == basicColor) {
					renderer.material.color = Color.white;
				} else {
					renderer.material.color = basicColor;
				}
				lastColor = renderer.material.color;
			}
			timeBlink = 20;
		} else
			--timeBlink;
		


	}
}
