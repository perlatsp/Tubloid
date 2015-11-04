using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	static int numBricks = 0;
	public int pointValue = 1;
	public int hitPoints = 1;
	public int powerUpChance = 3;
	public GameObject[] powerUpPrefabs;
	public bool AllPowerups;
	// Use this for initialization
	void Start () 
	{
		numBricks++;

	}//start
	
	// Update is called once per frame
	void Update () 
	{

	}//update

	void OnCollisionEnter( Collision col ) 
	{
		hitPoints--;
		
		if ( hitPoints <= 0 ) 
		{
			Die();
		}
	}

	
	void Die()
		{
			Destroy( gameObject );
			PaddleScript paddleScript = GameObject.Find ("paddle").GetComponent<PaddleScript>();
			paddleScript.AddPoints(pointValue);
			numBricks--;
			
			//PwerUps every brick
			if(AllPowerups)
			{
				Instantiate( powerUpPrefabs[ Random.Range(0, powerUpPrefabs.Length) ] , transform.position, Quaternion.identity );
			}
			if ( Random.Range(0, powerUpChance) == 0 ) 
				{
					if(!AllPowerups)
					{
						Instantiate( powerUpPrefabs[ Random.Range(0, powerUpPrefabs.Length) ] , transform.position, Quaternion.identity );
					}
			}	//	create powerups 




			if ( numBricks <= 0 ) 
				{
					Application.LoadLevel(Application.loadedLevel +1);
					print ("dasdasaaaaa");
					//Reset Paddle scale after level complete
					GameObject padlescale = GameObject.Find ("paddle");
					padlescale.transform.localScale = new Vector3(4f, 0.5f, 1f);
					
					print ("level loaded :  " +Application.loadedLevelName);
				}//endif 


		}//	Die

}//end class
