using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Transform pauseCanvas;
	public Transform guiCanvas;
	public Transform optionsCanvas;
	public Transform confirmCanvas;
	public Transform confirmMMCanvas;

	public void quitGame() {
		Application.Quit();
		//UnityEditor.EditorApplication.isPlaying = false;
	}

	public void restoreOptions() {
		confirmCanvas.gameObject.SetActive(false);
		optionsCanvas.gameObject.SetActive(true);
	}

	public void confirmQ() {
		optionsCanvas.gameObject.SetActive(false);
		confirmCanvas.gameObject.SetActive(true);
	}

	public void backToGame() {
		pauseCanvas.gameObject.SetActive(false);
		guiCanvas.gameObject.SetActive(true);
		Time.timeScale = 1;
	}

	public void goMainMenu() {
		Time.timeScale = 1;
		AudioListener.pause = false;
		for (int i = 0; i < SoundController.source.Length; ++i) {
			SoundController.source[i].Stop();
		}
		SceneManager.LoadScene(0);
	}

	public void confirmMainM() {
		optionsCanvas.gameObject.SetActive(false);
		confirmMMCanvas.gameObject.SetActive(true);
	}

	public void restoreOpMM() {
		confirmMMCanvas.gameObject.SetActive(false);
		optionsCanvas.gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(pauseCanvas.gameObject.activeInHierarchy == false) {
				pauseCanvas.gameObject.SetActive(true);
				guiCanvas.gameObject.SetActive(false);
				Time.timeScale = 0;
				AudioListener.pause = true;
			} else {
				AudioListener.pause = false;
				backToGame();
			}
		}
	}
}
