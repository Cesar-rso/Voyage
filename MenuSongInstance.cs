using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSongInstance : MonoBehaviour {

	public static MenuSongInstance MenuMusic = null;
	public GameObject music;

	void Awake () {
		
		string levelname = SceneManager.GetActiveScene().name; //Application.loadedLevelName;

		if(MenuMusic == null){
			MenuMusic = this;
				}else if(MenuMusic != null || levelname.Contains("level_") || levelname.Contains("BonusLevel") || levelname.Contains("Tutorial")){
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
		
	}
	
	// Use this for initialization
	void Start () {
		Instantiate(music, transform.position, transform.rotation);
		if(!transform.GetComponent<AudioSource>().isPlaying){
				transform.GetComponent<AudioSource>().Play();
		}
	}
	
	void Update (){
				if(SceneManager.GetActiveScene().name.Contains("level_")){
			Destroy(gameObject);
		}
	}
	
}
