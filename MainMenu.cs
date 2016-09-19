using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string[] btime = new string[10];
	public int currentlevel = 0;
	public int LastPLevel = 0;


	public void StartGame(){
		Load ();
		if(LastPLevel==0){
			Destroy(gameObject);
			//Application.LoadLevel(1);
			SceneManager.LoadScene (1);
		}else{
			//transform.GetComponentInChildren<AudioSource>().Play();
			//Application.LoadLevel("LevelSelect");
			SceneManager.LoadScene ("LevelSelect");
		}
	}
	
	public void Update(){
				if(Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name.Equals("ControlsScreen")){
				//Application.LoadLevel("MainMenu");
				SceneManager.LoadScene ("MainMenu");
			}
	}
	
	public void Controls(){
		//Application.LoadLevel("ControlsScreen");
		SceneManager.LoadScene ("ControlsScreen");
	}

	public void Credits(){
		//transform.GetComponentInChildren<AudioSource>().Play();
		//Application.LoadLevel("Credits");
		SceneManager.LoadScene ("Credits");
	}

	public void QuitGame(){
		//transform.GetComponentInChildren<AudioSource>().Play();
		Application.Quit();
	}

	public void Load (){
		if(File.Exists(Application.persistentDataPath + "/Fs.dat")){
			BinaryFormatter format = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Fs.dat",FileMode.Open);
			
			GameData data = (GameData)format.Deserialize(file);
			file.Close();
			btime = data.btime;
			currentlevel = data.currentlevel;
			LastPLevel = data.LastPLevel;
		}
	}
	
	public void StartBonus(){
		//Application.LoadLevel("BonusLevel");
		SceneManager.LoadScene ("BonusLevel");
	}
	
	public void StartTutorial(){
		//Application.LoadLevel("Tutorial");
		SceneManager.LoadScene ("Tutorial");
	}
	
}

[Serializable]
public class GameData{
	public string[] btime = new string[10];
	public int currentlevel;
	public int LastPLevel;
}
