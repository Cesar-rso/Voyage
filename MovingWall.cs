using UnityEngine;
using System.Collections;

public class MovingWall : MonoBehaviour {

	public GameObject leftpoint, rightpoint;
	public bool movement = true;
	public int speed = 2;
	
	// Update is called once per frame
	void Update () {
		
		if(movement){
			transform.position = Vector3.MoveTowards(transform.position,leftpoint.transform.position,speed*Time.deltaTime);
		}else{
			transform.position = Vector3.MoveTowards(transform.position,rightpoint.transform.position,speed*Time.deltaTime);
		}
		
		if(transform.position.x>=rightpoint.transform.position.x){
			movement = true;
		} else if(transform.position.x<=leftpoint.transform.position.x){
			movement = false;
		}
	
	}
}
