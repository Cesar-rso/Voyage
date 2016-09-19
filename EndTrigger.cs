using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

	public string[] btime = new string[10];
	public int currentlevel;
	public int LastPLevel;
	public GameObject timeObj;
	public SceneFadeInOut fade;

	void Start (){
		Load();
		currentlevel = SceneManager.GetActiveScene ().buildIndex;
		LastPLevel = SceneManager.GetActiveScene ().buildIndex;
		Time.timeScale = 1;
	}
	

	void Update(){
		if(SceneManager.GetActiveScene().name.Equals("GameOverScreen")){
			if(Input.GetKey(KeyCode.Escape)){
				//Application.LoadLevel(0);
				SceneManager.LoadScene (0);
			}
		}
	}

	IEnumerator NewLevel(){
		yield return new WaitForSeconds(1);
		//Application.LoadLevel(Application.loadedLevel + 1);
		fade.EndScene();
	}
	

	void OnTriggerEnter2D(Collider2D col){
		if(currentlevel==null || currentlevel<1){
			currentlevel = 1;
		}
		if(col.gameObject.name.Equals("Ball")){
			int prevTime;
			if(btime[currentlevel-1].Length<=0){
				prevTime = 0;
			}else{
				prevTime = (Int32.Parse(btime[currentlevel-1].Substring(0,2)))*60 + (Int32.Parse(btime[currentlevel-1].Substring(3,2)));
			}
			int currntTime = (Int32.Parse(timeObj.GetComponent<Text>().text.Substring(0,2)))*60 + (Int32.Parse(timeObj.GetComponent<Text>().text.Substring(3,2)));
			if(prevTime>currntTime||prevTime==0){
				btime[currentlevel-1]=timeObj.GetComponent<Text>().text;
			}
			if(LastPLevel<currentlevel){
				LastPLevel = currentlevel;
			}
			Save ();
			currentlevel = SceneManager.GetActiveScene ().buildIndex + 1;
			if(!transform.GetComponent<AudioSource>().isPlaying){
				transform.GetComponent<AudioSource>().Play();
				StartCoroutine(NewLevel());
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(currentlevel==null || currentlevel<1){
			currentlevel = 1;
		}
		if(col.gameObject.name.Equals("Ball")){
			int prevTime;
			if(btime[currentlevel-1].Length<=0){
				prevTime = 0;
			}else{
				prevTime = (Int32.Parse(btime[currentlevel-1].Substring(0,2)))*60 + (Int32.Parse(btime[currentlevel-1].Substring(3,2)));
			}
			int currntTime = (Int32.Parse(timeObj.GetComponent<Text>().text.Substring(0,2)))*60 + (Int32.Parse(timeObj.GetComponent<Text>().text.Substring(3,2)));
			if(prevTime>currntTime||prevTime==0){
				btime[currentlevel-1]=timeObj.GetComponent<Text>().text;
			}
			if(LastPLevel<currentlevel){
				LastPLevel = currentlevel;
			}
			Save ();
			currentlevel = SceneManager.GetActiveScene ().buildIndex + 1;
			if(!transform.GetComponent<AudioSource>().isPlaying){
				transform.GetComponent<AudioSource>().Play();
				StartCoroutine(NewLevel());
			}
		}
	}

	public void Save(){
		BinaryFormatter format = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Fs.dat");
		
		GameData data = new GameData();
		data.btime = btime;
		data.currentlevel = currentlevel;
		data.LastPLevel = LastPLevel+1;
		
		format.Serialize(file,data);
		file.Close();
	}

	public void Load (){
		if(File.Exists(Application.persistentDataPath + "/Fs.dat")){
			BinaryFormatter format = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Fs.dat",FileMode.Open);
			
			GameData data = (GameData)format.Deserialize(file);
			file.Close();
			LastPLevel = data.LastPLevel;
			btime = data.btime;
		}
	}

}
