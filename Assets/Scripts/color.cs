using UnityEngine;
using System.Collections;

public class color : MonoBehaviour {

	public bool IsRed;



	IEnumerator Example() 
	{

			GetComponent<Renderer>().material.color = Color.red;
			yield return new WaitForSeconds(2); 
			GetComponent<Renderer>().material.color=Color.white;

	}
	void Start()

	{
		StartCoroutine (Example());
	}
}