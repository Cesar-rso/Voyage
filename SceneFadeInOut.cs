using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.

	//public Canvas FadeCanvas;
	public Image FadeImage;
	
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	
	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		//FadeImage.minHeight = new Rect(0f, 0f, Screen.width, Screen.height);

	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		FadeImage.color = Color.Lerp(FadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		FadeImage.color = Color.Lerp(FadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(FadeImage.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			FadeImage.color = Color.clear;
			FadeImage.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		FadeImage.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		//Debug.Log (FadeImage.color.a);
		// If the screen is almost black...
		//if(FadeImage.color.a >= 0.95f)
			//Debug.Log (FadeImage.color.a+" inside");
			// ... load the next level.
		StartCoroutine(WaitNewLevel());	
		//Application.LoadLevel(Application.loadedLevel + 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	
	public void EndBonusScene ()
	{
		// Make sure the texture is enabled.
		FadeImage.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		//Debug.Log (FadeImage.color.a);
		// If the screen is almost black...
		//if(FadeImage.color.a >= 0.95f)
			//Debug.Log (FadeImage.color.a+" inside");
			// ... load the next level.
		StartCoroutine(WaitNewLevel());	
		//Application.LoadLevel("MainMenu");
		SceneManager.LoadScene ("MainMenu");
	}
	
	IEnumerator WaitNewLevel(){
		yield return new WaitForSeconds(1);
		
	}
}
