using UnityEngine;
using System.Collections;

public class BreakingWall : MonoBehaviour {

	public bool breaked = false;
	
	void OnCollisionEnter2D(Collision2D col){
		
		if((col.transform.name=="Ball"||col.transform.name=="ball")&&!breaked){
			transform.GetComponent<AudioSource>().Play();
			breaked = true;
		}
		
	}
}
