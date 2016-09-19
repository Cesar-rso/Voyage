using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	bool forceControl = false;
	// Update is called once per frame
	void Update () {
	//Ball Controls
		if((Input.GetKey("right")||Input.GetKey(KeyCode.D)) && transform.GetComponent<Rigidbody2D>().velocity.x < 6.0f){
			transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1200 * Time.deltaTime);
		}
		if((Input.GetKey("left")||Input.GetKey(KeyCode.A)) && transform.GetComponent<Rigidbody2D>().velocity.x > -6.0f){
			transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -1200 * Time.deltaTime);
		}
	//Ball Velocity limitation on x axis
		transform.GetComponent<Rigidbody2D>().angularVelocity = 0;
		transform.rotation.Set(0,0,0,0);
		if(GetComponent<Rigidbody2D>().velocity.x > 8.0f){
			GetComponent<Rigidbody2D>().velocity = new Vector2(8.0f,transform.GetComponent<Rigidbody2D>().velocity.y);
		}
		if(GetComponent<Rigidbody2D>().velocity.x < -8.0f){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-8.0f,transform.GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		//Ball response on wall hit (aceleration on y axis)
		if((col.gameObject.name.Equals("Wall")) && transform.GetComponent<Rigidbody2D>().velocity.y < 7.0f && !(Input.GetKeyDown("right")||Input.GetKeyDown("left")) && forceControl==false){
			forceControl = true;
			transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12500 * Time.deltaTime);
			transform.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
			Counter ();
			transform.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
		//Ball response on platform hit (aceleration on y axis)
		if((col.gameObject.name.Equals("Rotating_Plat")||col.gameObject.name.Equals("Moving_Plat")) && transform.GetComponent<Rigidbody2D>().velocity.y < 7.0f && !(Input.GetKeyDown("right")||Input.GetKeyDown("left")) && forceControl==false){
			forceControl = true;
			transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15000 * Time.deltaTime);
			transform.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
			Counter ();
			transform.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
		//Ball velocity limitation on y axis after floor hit
		if((col.gameObject.name.Equals("Floor")||col.gameObject.name.Equals("Ceiling"))&&GetComponent<Rigidbody2D>().velocity.y>7.0f){
			GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x,7.0f);
		}
		//Ball sound
		if(!(col.gameObject.name.Equals("EndTrigger")||col.gameObject.name.Equals("Door"))){
			transform.GetComponent<AudioSource>().Play();
		}
		forceControl = false;
	}

	IEnumerator Counter(){
		yield return new WaitForSeconds(0.5f);
	}
	
}
