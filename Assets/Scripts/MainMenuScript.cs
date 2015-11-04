using System;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
	public Texture Play;
	public Texture QuitGame;
	public Texture Credits;
	public Texture MainMenu;
	public Texture Instructions;
	public Texture ChangeGraphicsQuality;
	public Texture Fastest;
	public Texture Good;
	public Texture Fantastic;
	bool showGraphicsDropDown = false;
	public GameObject mymusic;

	public GUISkin skini;


	
	public AudioClip hoversound;
	public AudioClip beep;
	
	void OnMouseEnter()
	{
		GetComponent<AudioSource>().PlayOneShot(hoversound);
		transform.localScale += new Vector3(12F, 0, 0);
	}
	void OnMouseExit()
	{
		transform.localScale -= new Vector3(0.2F, 0, 0);
	}
	void OnMouseUp(){
		GetComponent<AudioSource>().PlayOneShot(beep);
		
		
	}
	
	
	
	void OnGUI()
	{
		GUI.skin = skini;
			//Make a background box
			//GUI.Box(new Rect(0 ,0,Screen.width,Screen.height),"");
			//GUI.Box(new Rect(0 ,0,Screen.width,Screen.height),"");
	//	GUI.Button (new Rect (10,10,100,20), GUIContent ("Button aaa1", "Button 1"));
	

			//Make quit game button
		if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2 -50,250,50), Play))
		{
			Application.LoadLevel("level1");
		}

		if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2 + 60,250,50), Credits))
		{	
			Application.LoadLevel("Credits");


		}

		if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2 + 115,250,50), Instructions))
		{
			Application.LoadLevel("Instructions");
		}

		if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2 + 170,250,50), QuitGame))
		{
			Application.Quit();
		}



		//Make Change Graphics Quality button
		if(GUI.Button(new Rect(Screen.width /2 - 100,Screen.height /2 + 5,250,50), ""))
		{
			
			if(showGraphicsDropDown == false)
			{
				showGraphicsDropDown = true;
			}
			else
			{
				showGraphicsDropDown = false;
			}
		}
		
		
		if(showGraphicsDropDown == true) 
			{
				if(GUI.Button(new Rect(Screen.width /2 + 155,Screen.height /2 ,250,50), Fastest))
				{
					QualitySettings.currentLevel = QualityLevel.Fastest;
				}
				
				if(GUI.Button(new Rect(Screen.width /2 + 155,Screen.height /2 + 50,250,50), Good))
				{
					QualitySettings.currentLevel = QualityLevel.Good;
				}
				
				if(GUI.Button(new Rect(Screen.width /2 + 155,Screen.height /2 + 100,250,50), Fantastic))
				{
					QualitySettings.currentLevel = QualityLevel.Fantastic;
				}
			}




	}	//onGUI

}