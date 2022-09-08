using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject readyText;
	public float moveSpeedReadyT = 5;

	public static int score;
	public static int highScore;
	public static int level;
	private int lives;

	public Text testing;
	public Text scoreText;
	public Text highScoreText;
	public Text levelText;
	public Text livesText;

	private bool isEating;

	int elapsed_time;
	int starting_time;

	float x, y;
	float posx, posy, posz;
	bool entrat;

	GameObject pacman;
	GameObject map;
	Player pacmanScript;
	SoundController pacmanScriptMusic;

	bool starting;

	private float distanceCameraPacman;

	void getComponents()
	{
		x = GameObject.Find("Pacman").GetComponent<Player>().x;
		y = GameObject.Find("Pacman").GetComponent<Player>().y;
		lives = GameObject.Find("Pacman").GetComponent<Player>().lives;
		posx = GameObject.Find("Pacman").GetComponent<Player>().transform.position.x;
		posy = GameObject.Find("Pacman").GetComponent<Player>().transform.position.y;
		posz = GameObject.Find("Pacman").GetComponent<Player>().transform.position.z;
	}

	void detectTeleport() 
	{
		Vector3 temp;

		if(posx <= -180.0f && posx > -185.0f && posz < -11.0f && posz > -15.0f) {
			temp = new Vector3(129, 5, -14);
			pacman.GetComponent<Player>().transform.position = temp;
		} else if(posx >= 130.0f && posx < 135.0f && posz < -11.0f && posz > -15.0f) {
			temp = new Vector3(-179, 5, -14);
			pacman.GetComponent<Player>().transform.position = temp;
		} else {
			entrat = false;
		}


	}

	// Use this for initialization
	void Start () {
		AudioListener.pause = false;
		//level = 1;	// TEMPORAL
		starting_time = (int)Time.time;
		entrat = false;
		starting = true;
		getComponents();
		highScore = 0;
		elapsed_time = 0;
		pacman = GameObject.Find("Pacman");
		map = GameObject.Find("Map");
		pacmanScript = pacman.GetComponent<Player>();
		pacmanScriptMusic = map.GetComponent<SoundController>();
	}
	
	// Update is called once per frame
	void Update () {
		elapsed_time = (int)Time.time - starting_time;
		if(elapsed_time >= 4) {
			Player.move = true;
			starting = false;
			readyText.SetActive(false);
		}
		getComponents();
		printTestText();
		printText();

		if(starting) {	
			readyText.transform.position += Vector3.up * Time.deltaTime * moveSpeedReadyT;
		} else {	// End starting song
			detectTeleport();
		}
	}

	void printTestText() 
	{
		testing.text = "x: " + x.ToString() + '\n';
		testing.text += "y: " + y.ToString() + '\n';
		testing.text += "Position X: " + posx.ToString() + '\n';
		testing.text += "Position Y: " + posy.ToString() + '\n';
		testing.text += "Position Z: " + posz.ToString() + '\n';
		testing.text += "Rotation X: " + GameObject.Find("Pacman").GetComponent<Player>().transform.eulerAngles.x + '\n';
		testing.text += "Rotation Y: " + GameObject.Find("Pacman").GetComponent<Player>().transform.eulerAngles.y + '\n';
		testing.text += "Rotation Z: " + GameObject.Find("Pacman").GetComponent<Player>().transform.eulerAngles.z + '\n';
		//testing.text += "Camera Position X: " + GameObject.Find("Main Camera").transform.position.x + '\n';
		//testing.text += "Camera Position Y: " + GameObject.Find("Main Camera").transform.position.y + '\n';
		//testing.text += "Camera Position Z: " + GameObject.Find("Main Camera").transform.position.z + '\n';
		testing.text += "Entrat: " + entrat.ToString() + '\n';
		testing.text += "Distance Camera: " + distanceCameraPacman.ToString() + '\n';
		testing.text += "Cube Face: " + TeleportsMap2.cubeFace.ToString() + '\n';
		testing.text += "Teleport: " + TeleportsMap2.entro.ToString() + '\n';
	}

	void printText()
	{
		scoreText.text = "Score " + score.ToString();
		levelText.text = "Level " + level.ToString();
		livesText.text = "Lives " + lives.ToString();
		highScoreText.text = "High Score " + elapsed_time.ToString();
	}
		

}
