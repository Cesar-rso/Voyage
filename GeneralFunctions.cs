using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralFunctions : MonoBehaviour {

	public Canvas pauseMenu;

	void Start () {

		pauseMenu.enabled = false;
	
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Escape)){
			Time.timeScale = 0;
			pauseMenu.enabled = true;
		}
	
	}
}
