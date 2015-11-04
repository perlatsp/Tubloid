using UnityEngine;
using System.Collections;

public class Level_Timer : MonoBehaviour {
	/*
	public GameObject character;	
	public int countMax;  //max countdown number
	private int countDown;  //current countdown number
	public GUIText GUI_Timer;//GUIText reference

	void Awake () 
	{
		//Disable paddle Movement
		character.GetComponent<PaddleScript>().enabled = false;

		StartCoroutine(CountdownFunction());
		DontDestroyOnLoad (GUI_Timer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator CountdownFunction() 
	{
		//start the countdown
		for(countDown = countMax; countDown > -1; countDown-- )
			{
				if(countDown!=0)
					{
						//display the number to the screen via the GUIText
						GUI_Timer.text = countDown.ToString();
						//add a one second delay
						yield return new WaitForSeconds(1);    
					}
				else
					{
						//GUI_Timer.text = "";
						//yield return new WaitForSeconds(1);
					character.GetComponent<PaddleScript>().enabled = true;
					GUI_Timer.enabled = false;
					}
			}

	}
	*/
}