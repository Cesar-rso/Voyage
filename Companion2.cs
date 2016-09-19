using UnityEngine;
using System.Collections;

public class Companion2 : MonoBehaviour {

	public GameObject TargetToFollow, LastPosition, LastPosition2, LastPosition3;
	public float speed=5f, RefreshRate=1f, time=0, totaltime;
	public bool gotCompanion = false;

	
	// Update is called once per frame
	void Update () {
	
		totaltime = Time.timeSinceLevelLoad;
		
		if(gotCompanion){
			if((totaltime - time) >= RefreshRate){
				LastPosition3.transform.position = LastPosition2.transform.position;
				LastPosition2.transform.position = LastPosition.transform.position;
				LastPosition.transform.position = TargetToFollow.transform.position;
				time = totaltime;
			}
			transform.position = Vector3.MoveTowards(transform.position, LastPosition3.transform.position, speed * Time.deltaTime);
		}
	
	}
	
	void OnCollisionEnter2D(Collision2D col){

		if(col.transform.name=="Ball"||col.transform.name=="ball"){
			gotCompanion = true;
		}
		
		//Ball sound
		if(!(col.gameObject.name.Equals("EndTrigger")||col.gameObject.name.Equals("Door"))&&gotCompanion){
			transform.GetComponent<AudioSource>().Play();
		}


	}
}
