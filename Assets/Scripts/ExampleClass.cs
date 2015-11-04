using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	[Range(0.0F, 10.0F)]
	public float myFloat = 0.0F;
	[Range(0.0f, 100f)]
	public float per = 0f;
}