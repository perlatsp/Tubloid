using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	bool paused = false;
	bool showGraphicsDropDown = false;
	public Texture Play;
	public Texture Resume;
	public Texture GamePaused;
	public Texture MainMenu;
	public Texture QuitGame;
	public Texture ChangeGraphicsQuality;
	public Texture Fastest;
	public Texture Fast;
	public Texture Simple;
	public Texture Good;
	public Texture Beautiful;
	public Texture Fantastic;

	void Update()
	{
		if(Input.GetKeyDown("escape"))
			paused = togglePause();
	}
	
	void OnGUI()
	{
		
		GUI.skin.settings.cursorColor = Color.cyan;

		if(paused)
		{




			//Make a background box
			GUI.Box(new Rect(0 ,0,Screen.width,Screen.height), GamePaused);


			//Resume Button
			if(GUI.Button(new Rect(Screen.width /2  -100,Screen.height /2 - 100,250,50), Resume))
			{
				paused = togglePause();

			}

			//Make Main Menu button
			if(GUI.Button(new Rect(Screen.width /2 - 100,Screen.height /2 - 45,250,50), MainMenu))
			{
				DestroyAllGameObjects();

				paused = togglePause();
				Application.LoadLevel("MainMenu");
			}
			
			//Make Change Graphics Quality button
			if(GUI.Button(new Rect(Screen.width /2 - 100,Screen.height /2 + 10,250,50), ChangeGraphicsQuality))
			{
				
				if(showGraphicsDropDown == false)
				{
					showGraphicsDropDown = true;
				}
				else
				{
					showGraphicsDropDown = false;
				}//endelse
			}//endif
			

			if(showGraphicsDropDown == true)
			{
				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 ,250,50), Fastest))
				{
					QualitySettings.currentLevel = QualityLevel.Fastest;
				}

				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 + 50,250,50), Good))
				{
					QualitySettings.currentLevel = QualityLevel.Good;
				}

				if(GUI.Button(new Rect(Screen.width /2 + 150,Screen.height /2 + 100,250,50), Fantastic))
				{
					QualitySettings.currentLevel = QualityLevel.Fantastic;
				}
				
				if(Input.GetKeyDown("escape")){
					showGraphicsDropDown = false;
				}
			}
			
			//Make quit game button
			if (GUI.Button (new Rect (Screen.width /2 - 100,Screen.height /2 + 65,250,50), QuitGame)){
				Application.Quit();
			}

		}
	}







	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}



	public void DestroyAllGameObjects()
	{

		GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
		for (int i = 0; i < GameObjects.Length; i++)
		{
			Destroy(GameObjects[i]);	
		
		}




}
}//Telos PauseMenu