using UnityEngine;
using System.Collections;

public class MovingPlat : MonoBehaviour {

	public GameObject downpoint, uppoint;
	public bool movement = true;
	public int speed = 2;
	
	
	// Update is called once per frame
	void Update () {
	
		if(movement){
			transform.position = Vector3.MoveTowards(transform.position,downpoint.transform.position,speed*Time.deltaTime);
		}else{
			transform.position = Vector3.MoveTowards(transform.position,uppoint.transform.position,speed*Time.deltaTime);
		}
		
		if(transform.position.y>=uppoint.transform.position.y){
			movement = true;
		} else if(transform.position.y<=downpoint.transform.position.y){
			movement = false;
		}
	}
	
}
