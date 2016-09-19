using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void Resumelevel(Canvas PauseCanvas){
		PauseCanvas.enabled = false;
		Time.timeScale = 1;
	}

	public void Restart(){
		Time.timeScale = 1;
		//Application.LoadLevel (Application.loadedLevel);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Quit(){
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}
}
