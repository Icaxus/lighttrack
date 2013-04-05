using UnityEngine;
using System.Collections;


public class LightEffects : MonoBehaviour {
	
	public float intensityMultiplier = 6.5f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.light.intensity = intensityMultiplier;
	}
}
