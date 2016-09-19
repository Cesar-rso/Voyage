using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool buttonSelected;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
				if (SceneManager.GetActiveScene ().name.Equals ("MainMenu") || SceneManager.GetActiveScene ().name.Contains("level_") || SceneManager.GetActiveScene ().name.Contains("BonusLevel") || SceneManager.GetActiveScene ().name.Contains("Tutorial")) {
			if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
				eventSystem.SetSelectedGameObject (selectedObject);
				buttonSelected = true;
			}
		}
		if (SceneManager.GetActiveScene ().name.Equals ("LevelSelect")) {
			if (Input.GetAxisRaw ("Horizontal") != 0 && buttonSelected == false) {
				eventSystem.SetSelectedGameObject (selectedObject);
				buttonSelected = true;
			}	
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
}