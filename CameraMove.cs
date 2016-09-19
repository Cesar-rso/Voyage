using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if((transform.position.x < ball.transform.position.x - 0.1f)||(transform.position.x > ball.transform.position.x + 0.1f)||
		   (transform.position.x < ball.transform.position.y - 0.1f)||(transform.position.x > ball.transform.position.y + 0.1f)){
			Vector3 ballposition;
			ballposition = ball.transform.position;
			ballposition.z = transform.position.z;
			transform.position = ballposition;
		}
	}
}
