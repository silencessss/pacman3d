using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class GhostInteligentLevel2 : MonoBehaviour {

	// Use this for initialization
	NavMeshAgent agent;
	public Transform returnPosition;

	public Quaternion initialRotation;
	public Vector3 initialPosition;

	bool isScaredActive;
	GameObject ScaredGhost;
	GameObject NormalGhost;

	private int timeBlink = 0;

	public bool isDeath = false;

	private Animator scaredAnimator;


	public bool isRunningAway = false;

	public float remainningDistance;

	public float pauseDelay = 0;

	Color lastColor;
	Color basicColor;

	bool isAgentStopped; 

	GameObject Pacman;
	void Start () {
		ScaredGhost = this.transform.GetChild (1).gameObject;
		NormalGhost = this.transform.GetChild (0).gameObject;
		scaredAnimator = ScaredGhost.GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent> ();
		Pacman = GameObject.Find("Pacman");
		pauseDelay = 0;
		isRunningAway = false;
		isScaredActive = false;
		initialPosition = transform.position;
		initialRotation = transform.rotation;
		basicColor = ScaredGhost.transform.Find ("Cylinder").GetComponent<Renderer> ().material.color;
		lastColor = Color.black;
		timeBlink = 0;
		isAgentStopped = false;
	}

	// Update is called once per frame
	void Update () {


		remainningDistance = agent.remainingDistance;
		if (Player.move && !Player.isDeath) {

			if (isAgentStopped) {
				agent.Resume ();
				isAgentStopped = false;
			}

			if (pauseDelay == 0) {
				if (!isRunningAway)
					agent.destination = Pacman.transform.position;

				if (isRunningAway && CompareVector(agent.destination, returnPosition.position) && CompareVector(transform.position, returnPosition.position) ) {
					toNormalState ();
				}

			} else {
				--pauseDelay;
				if (pauseDelay == 0) {
					Time.timeScale = 1;
					agent.Resume ();
				}

			}
		}
		else if (Player.isDeath && !isAgentStopped) {
			agent.Stop ();
			isAgentStopped = true;
		} 
	}


	public void setIsRunningAway() 
	{
		agent.destination = returnPosition.position;
		isRunningAway = true;
		isScaredActive = true;
		NormalGhost.SetActive (false);
		ScaredGhost.SetActive (true);
		scaredAnimator.SetBool ("isScared", true);
		//Speed, angular and aceleration modifications
		agent.speed = 1;
		agent.angularSpeed = 120;
		agent.acceleration = 50;

	}

	private bool CompareVector(Vector3 a, Vector3 b) {
		float diff = Mathf.Abs (a.sqrMagnitude - b.sqrMagnitude);
		print (diff);
		if (diff < 15)
			return true;
		return false;

	}


	public void returnToInitialPosition() {
		agent.Warp (initialPosition);
		transform.rotation = initialRotation;
		pauseDelay = 200;
	}


	public bool getIsRunningAway() {
		return isRunningAway;
	}

	public void isDeathTime() {

		ScaredGhost.transform.Find("Cylinder").gameObject.SetActive(false);
		ScaredGhost.transform.Find ("Plane").gameObject.SetActive (false);
		//Speed, angular and aceleration modifications

		isDeath = true;
		Time.timeScale = 0;
		pauseDelay = 10;
		agent.Stop ();
		//Speed, angular and aceleration modifications
		agent.speed = 3;
		agent.angularSpeed = 120;
		agent.acceleration = 50;

		agent.destination = returnPosition.position;
		isRunningAway = true;

	}

	public void toNormalState() {

		scaredAnimator.SetBool ("isScared", false);
		ScaredGhost.transform.Find ("Cylinder").gameObject.GetComponent<Renderer> ().material.color = basicColor;

		ScaredGhost.SetActive (false);

		NormalGhost.SetActive (true);

		isDeath = false;

		isRunningAway = false;

		//Speed, angular and aceleration modifications
		agent.speed = 2;
		agent.angularSpeed = 120;
		agent.acceleration = 50;


		if (!ScaredGhost.transform.Find ("Cylinder").gameObject.activeSelf) {
			ScaredGhost.transform.Find ("Cylinder").gameObject.SetActive (true);
			ScaredGhost.transform.Find ("Plane").gameObject.SetActive (true);
		}

		timeBlink = 0;
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
