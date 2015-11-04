 using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	#region Dhlwsh metablhtwn

	public AudioClip[] audioss;

	#endregion


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Die() {
		Destroy( gameObject );
		GameObject paddleObject = GameObject.Find("paddle");
		PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript>();
		paddleScript.LoseLife();

	}
	void OnCollisionEnter(Collision col)
	{
			//
		if (col.transform.gameObject.name == "brick") 
		{
			GetComponent<AudioSource>().PlayOneShot (audioss [0]);
		}//end if 

		if (col.transform.gameObject.name == "BrickNOBREAK") 
		{
			GetComponent<AudioSource>().PlayOneShot (audioss [2]);
		}//end if 

		if(col.transform.gameObject.name=="brickHard")
		{
			GetComponent<AudioSource>().PlayOneShot (audioss[4]);
		}//end if
		if (col.transform.gameObject.name == "wallTop" || col.transform.gameObject.name == "wallLeft" || col.transform.gameObject.name == "wallRight") 
		{
			GetComponent<AudioSource>().PlayOneShot (audioss [1]);
		}//end if

	
	}
}
