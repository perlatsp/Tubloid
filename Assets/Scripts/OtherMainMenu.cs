using System;
using UnityEngine;

public class OtherMainMenu : MonoBehaviour
{
	public Texture GoBack;
	public Texture QuitGame;


	public GUISkin theskin;
	void Update()
	{
		
	}
	void Start()
	{
		
	}
	
	void OnGUI()
	{
		
		GUI.skin = theskin;
		
		//GUI.backgroundColor = Color.clear;

		//Make quit game button
		if (GUI.Button (new Rect (Screen.width /2 - 50,Screen.height /2 + 100,200,50), GoBack))
		{
			Application.LoadLevel("MainMenu");
		}

		if (GUI.Button (new Rect (Screen.width /2 - 350,Screen.height /2 + 100,200,50), QuitGame))
		{
			Application.Quit();
		}

		
	}	//onGUI
	
}