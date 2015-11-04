using System;
using UnityEngine;
public class NewMainMenu : MonoBehaviour
{
	 public AudioClip hoversound;
	 public AudioClip clicksound;
   //  public string Level;
	public enum leveli { level1, Credits, Instructions}
	public leveli Level;
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
	
			Application.LoadLevel (Level.ToString());
	

		 }


	
	
}