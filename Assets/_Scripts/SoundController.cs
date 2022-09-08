using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioSource beginingMusic;
	public AudioSource eatingMusic;
	public AudioSource deadMusic;
	public AudioSource intermissionMusic;
	public AudioSource powerUpMusic;

	private int elapsed_time;
	private int starting_time;
	private bool starting;

	public bool isEating;

	public static AudioSource[] source;

	void Awake() {
		source = GetComponents<AudioSource>();
		beginingMusic = source[0];
		eatingMusic = source[1];
		deadMusic = source[2];
		intermissionMusic = source[3];
		powerUpMusic = source[4];
	}

	// Use this for initialization
	void Start () {
		elapsed_time = 0;
		starting = true;
		starting_time = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		elapsed_time = (int) Time.time - starting_time;
		if(elapsed_time >= 4 || starting == false) {
			starting = false;
		} else {
			if(!beginingMusic.isPlaying) {
				beginingMusic.Play();
				starting = false;
			}
		}
	}


	public void playMusic(int id) {
		if(!source[id].isPlaying) {
			if(id == 2) {	// dead sound
				source[id].PlayDelayed(1);
			} else if(id == 4) {
				source[id].Play();
				source[3].PlayDelayed(0.8f);
			} else {
				source[id].Play();
			}
		}
	}
}
