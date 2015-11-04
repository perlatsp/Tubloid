using UnityEngine;
using System.Collections;

public class MainMenu_Exit_Script : MonoBehaviour 
{


	public AudioClip hoversound;
	public AudioClip clicksound;
	//  public string Level;

	void OnMouseEnter()
	{
		GetComponent<AudioSource>().PlayOneShot(hoversound);
		transform.localScale += new Vector3(0.05F, 0, 0);
	}
	void OnMouseExit()
	{	
		transform.localScale -= new Vector3(0.05F, 0, 0);
	}
	
	void OnMouseUp()
	{

		GetComponent<AudioSource>().PlayOneShot(clicksound);
		Application.Quit();		
	}



}