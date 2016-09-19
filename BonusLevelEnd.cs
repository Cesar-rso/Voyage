using UnityEngine;
using System.Collections;

public class BonusLevelEnd : MonoBehaviour {
	
	public SceneFadeInOut fade;

	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Equals("Ball")){
			//Application.LoadLevel("MainMenu");
			if(!transform.GetComponent<AudioSource>().isPlaying){
				transform.GetComponent<AudioSource>().Play();
			}
			StartCoroutine(EndBonus());
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name.Equals("Ball")){
			//Application.LoadLevel("MainMenu");
			if(!transform.GetComponent<AudioSource>().isPlaying){
				transform.GetComponent<AudioSource>().Play();
			}
			StartCoroutine(EndBonus());
		}
	}
	
	IEnumerator EndBonus(){
		yield return new WaitForSeconds(1);
		//Application.LoadLevel(Application.loadedLevel + 1);
		fade.EndBonusScene();
	}
}
