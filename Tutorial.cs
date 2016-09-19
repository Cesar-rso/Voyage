using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject TutorialObj;
	public int TutorialCheck = 0;
	
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log(TutorialObj.GetComponent<Text>().text);
		
		if(col.gameObject.name.Equals("TutorialTrigger 1")&& TutorialCheck==0){
			TutorialObj.GetComponent<Text>().text = "To get to higher places you will need to bounce off walls. The closer you are before bouncing, higher is your jump. And remember to release the movement key before bouncing or the ball will just turn around and fall.";
			TutorialCheck++;
		}
		
		if(col.gameObject.name.Equals("TutorialTrigger 2")&& TutorialCheck==1){
			TutorialObj.GetComponent<Text>().text = "Well done!";
			TutorialCheck++;
		}
		
		if(col.gameObject.name.Equals("TutorialTrigger 3")&& TutorialCheck==2){
			TutorialObj.GetComponent<Text>().text = "There's something different with that block. Maybe it's some kind of trick.";
			TutorialCheck++;
		}
		
		if(col.gameObject.name.Equals("TutorialTrigger 4")&& TutorialCheck==3){
			TutorialObj.GetComponent<Text>().text = "Sometimes bouncing off walls is not enough to get to those tricky platforms. But you can always trust in a helpful well-placed block. Just bounce on top of it to get to that platform on the right.";
			TutorialCheck++;
		}
		
		if(col.gameObject.name.Equals("TutorialTrigger 5")&& TutorialCheck==4){
			TutorialObj.GetComponent<Text>().text = "Nice! Just go to the door and the level is over.";
			TutorialCheck++;
		}
	}
}
