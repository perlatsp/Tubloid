using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour 
{
	#region Dhlwsh_metablhtwn
	GameObject sas;
	float paddleSpeed = 10f;
	public GameObject ballPrefab;
	GameObject attachedBall = null;
	public	int lives = 3;
	public GUIText guiLives;
	public GUIText guiscore;
	public GUIText CurrentLevel;
	GameObject newlives;
	public int score = 0;
	public GUISkin scoreboardSkin;
	
	
	//MaxPosition And Scale
	float MaxPos = 7.4f;
	float MaxExpand = 2f;
	float MaxShrink = 2f;
	
	public AudioClip[] PowerUpSounds;
	
	//CountDown
	public bool EnableCountDown = false;
	public GameObject character;	
	public int countMax;  //max countdown number
	private int countDown;  //current countdown number
	public GUIText GUI_Timer;//GUIText reference
	public Light light;
	public Light SpotLight;
	public GameObject FlameFloor ;
	public float duration = 0.2F;
	public GameObject allguis;
	#endregion
	
	//----------------------------------- End Of Delcarations --------------------------------------------------------------------------------------------------
	

	
	public void AddPoints(int v) 
	{
		score += v;
		guiscore = GameObject.Find("GuiScore").GetComponent<GUIText>();
		 
		guiscore.text = "Score : " + score;
		
		
	}		//AddPoints
	
	
	
	
	//	----------------------CountDown-------------------------------------
	
	//3 Seconds COUNTDOWN
	IEnumerator CountdownFunction() 
	{

		//start the countdown
		for(countDown = countMax; countDown > -1; countDown-- )
		{
			if(countDown!=0)
			{
				//display the number to the screen via the GUIText
				GUI_Timer.text = countDown.ToString();
				GetComponent<AudioSource>().PlayOneShot(PowerUpSounds[4]);
			
				//add a one second delay
				yield return new WaitForSeconds(1);  
			
			}//endif
			else
			{
				GUI_Timer.text = "GO";
				GetComponent<AudioSource>().PlayOneShot(PowerUpSounds[5]);
				yield return new WaitForSeconds(1);
				character.GetComponent<PaddleScript>().enabled = true;
				light.GetComponent<AudioSource>().enabled = true;
				light.intensity=3f; //open lights :D
				SpotLight.enabled = false;
				FlameFloor.GetComponent<ParticleSystem>().enableEmission=true; //enable flames 
				GUI_Timer.enabled = false;
				guiLives.enabled=true;
				guiscore.enabled=true;
				CurrentLevel.enabled=true;

			}
		}
		
		
		
	}//Countdown
	
	
	
	
	// Use this for initialization
	void Awake () 
	{
		FlameFloor.GetComponent<ParticleSystem>().enableEmission=false;
		guiLives.enabled=false;
		//guiscore.enabled=false;
		CurrentLevel.enabled=false;
		//EnableCountDown=false;
		//check if 
		if(EnableCountDown)
		{
			character.GetComponent<PaddleScript>().enabled = false;
			StartCoroutine(CountdownFunction());
			print (EnableCountDown);
		}//endif 
		
		DontDestroyOnLoad (GUI_Timer);
		DontDestroyOnLoad(CurrentLevel);
		//SpawnBall();
		
		DontDestroyOnLoad(gameObject);	//Dont Destroy Paddle
		
		
		guiLives = GameObject.Find("guiLives").GetComponent<GUIText>();
		guiscore = GameObject.Find("GuiScore").GetComponent<GUIText>();
		
		guiscore.text = "Score : " + score;
		guiLives.text = "Lives : " + lives;
		
		
		
		
	}//start
	
	
	
	
	
	
	void OnLevelWasLoaded( int level ) 
	{
		SpawnBall();
		
		if(Application.loadedLevelName  == "gameOver" || Application.loadedLevelName == "WinScene" )
		{
			print ("heeeeelp");
			guiscore.enabled=true;
			guiLives.enabled=false;
			CurrentLevel.enabled=false;
			guiscore.text="Your Score is : " + score;
			guiscore.transform.position = new Vector3(0.3935513f,0.54595762f,0);
			guiscore.fontSize =35;
			
		}
	}
	
	
	
	public void LoseLife() 
	{
		lives--;//Decrease lives by 1
		
		
		if (lives > 0) 		//Check if have lives left to spawn the ball
		{
			SpawnBall ();
		}
		else 
		{
			character.GetComponent<PaddleScript>().enabled = false;
			Application.LoadLevel("gameOver");		//Load GameOver Scene
		}
	}	//LoseLife
	
	
	// Spawn/Instantiate new ball
	public void SpawnBall() 
	{
		attachedBall = (GameObject)Instantiate( ballPrefab, transform.position + new Vector3(0, .75f, 0), Quaternion.identity );
	}	//SpawnBall
	
	
	
	
	
	
	
	
	void Update () 
	{

		//Display Current Level
		CurrentLevel = GameObject.Find ("CurrentLevel").GetComponent<GUIText>();
		CurrentLevel.text = "Level : " + Application.loadedLevel;
	
		
		
		
		//Score And Lives 
		guiLives = GameObject.Find("guiLives").GetComponent<GUIText>();
		guiscore = GameObject.Find("GuiScore").GetComponent<GUIText>();
		guiscore.text = "Score : " + score;
		guiLives.text = "Lives : " + lives;
		DontDestroyOnLoad (guiLives);
		DontDestroyOnLoad (guiscore);
		DontDestroyOnLoad (CurrentLevel);
		
		
		
		// Left-Right Movement 
		
		transform.Translate( paddleSpeed *2 * Time.deltaTime * Input.GetAxis( "Horizontal" ), 0, 0 );		//LeftRight With A-D
		transform.Translate( paddleSpeed *2 * Time.deltaTime * Input.GetAxis( "Mouse X" ), 0, 0 );		//LeftRight with MOuse
		
		if ( transform.position.x > MaxPos ) 
		{
			transform.position = new Vector3( MaxPos, transform.position.y, transform.position.z );
		}
		if ( transform.position.x < -MaxPos ) 
		{
			transform.position = new Vector3( -MaxPos, transform.position.y, transform.position.z );
		}
		
		
		
		
		if( attachedBall ) 
		{
			Rigidbody ballRigidbody = attachedBall.GetComponent<Rigidbody>();
			ballRigidbody.position = transform.position + new Vector3(0, .75f, 0);
			
			if( Input.GetButtonDown( "LaunchBall" ) || Input.GetMouseButtonDown(0) ) 
			{
				// Fire the ball
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce(300f * Input.GetAxis( "Horizontal" ), 300f, 0);
				attachedBall = null;
			}
		}
	}//Update
	
	
	
	
	
	
	
	
	
	public void OnCollisionEnter( Collision col ) 
	{
		foreach (ContactPoint contact in col.contacts) 
		{
			if( contact.thisCollider == GetComponent<Collider>() ) 
			{
				// This is the paddle's contact point
				float english = contact.point.x - transform.position.x;
				
				contact.otherCollider.GetComponent<Rigidbody>().AddForce( 300f * english, 0, 0);
			}
		}	//foreach
		
		
		//Ball sound 
		if (col.transform.gameObject.name == "ball(Clone)")
		{
			GetComponent<AudioSource>().PlayOneShot(PowerUpSounds[3]);
			StartCoroutine (Example ());
			
			
			
		}
		
		
		
		//------------------POWER UPS ----------------------------------------------------------------------------------------------------------------------
		#region Power_Ups
		
		#region Expand_PowerUP
		//Expand Power up
		if (col.transform.gameObject.name == "Expand(Clone)")
		{
			
			
			//no more scale after 3 scales
			if (MaxExpand >-1)
			{	
				transform.localScale += new Vector3(1F, 0, 0);
				print (MaxExpand);
				GetComponent<AudioSource>().PlayOneShot (PowerUpSounds [0]);
				MaxExpand--;
				MaxShrink++;
				MaxPos-=0.5f;				
			}
			else
			{
				//play error sound
				GetComponent<AudioSource>().PlayOneShot(PowerUpSounds[2]);
				
				print (MaxExpand);
			}
		}//end if powerup expand
		
		
		
		
		#endregion
		
		
		
		
		#region  Shrink_PowerUP
		//Shrink powerup
		if (col.gameObject.name == "Shrink(Clone)")
		{
			//no more scale after 3 scales
			if (MaxShrink >0)
			{	
				transform.localScale -= new Vector3(1F, 0, 0);
				Debug.Log("MaxShrink");
				print (MaxShrink);
				GetComponent<AudioSource>().PlayOneShot (PowerUpSounds [1]);
				MaxShrink--;
				MaxExpand++;
				
				MaxPos+=0.5f;				
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(PowerUpSounds[2]);
				
				print (MaxShrink);
			}
		}
		#endregion
		
		
		
		//Red Power up
		if (col.gameObject.name == "myheart(Clone)")
		{
			lives++;
			guiLives.text = "Lives : " + lives;
			GetComponent<AudioSource>().PlayOneShot (PowerUpSounds[6]);
		}			
		
		//Green Power up
		if (col.gameObject.name == "PowerUpGreen(Clone)")
		{
			lives++;
			guiLives.text = "Lives : " + lives;
			score +=300;
		}			
		
		//Purple Power up	
		if (col.gameObject.name == "PowerUpPurple(Clone)")
		{
			//score +=400;
			
			print ("Purple power up got");
			
		}			
		
		if (col.gameObject.name == "PowerUpBlue(Clone)")
		{
			score = score + 10000;
			guiscore.text = "Score : " + score ;
		}			//Blue Power up
		
		
		//-------------POWER UPS ----------------------- 
		
		#endregion
	}	//OnColliderEnter
	
	//change color on collision with the ball
	
	IEnumerator Example() 
	{
		
		GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.1f); 
		GetComponent<Renderer>().material.color=Color.white;
		
	}
	
	
	void OnGui()
	{
		GUI.skin= scoreboardSkin;
		GUI.Box(new Rect(0 ,0,Screen.width,Screen.height), "asdasd");
	}
	
}//PaddleScript Class


