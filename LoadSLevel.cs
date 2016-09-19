using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class LoadSLevel : MonoBehaviour {

	public GameObject levelbutton;

	public string[] btime = new string[10];
	public int currentlevel = 0;
	public int LastPLevel = 0;

	// Use this for initialization
	void Start () {
		Load ();
		if(Int32.Parse(transform.gameObject.name.Substring(6,1))>LastPLevel){
			levelbutton.SetActive(false);
			//Destroy(this);
		} else{
			transform.gameObject.GetComponentInChildren<Text>().text = btime[Int32.Parse(transform.gameObject.name.Substring(6,1))-1];
		}
	}


	public void LoadLevel(){
		SceneManager.LoadScene(Int32.Parse(transform.gameObject.name.Substring(6,1)));
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
}
