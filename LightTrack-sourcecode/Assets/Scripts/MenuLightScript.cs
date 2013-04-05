using UnityEngine;
using System.Collections;

public class MenuLightScript : MonoBehaviour {
	
	public GameObject light;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetMouseButtonDown(0))
		{
		light.animation.Play();
		
		}
	}
}
