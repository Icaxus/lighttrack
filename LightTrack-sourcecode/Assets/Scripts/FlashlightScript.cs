using UnityEngine;
using System.Collections;

public class FlashlightScript : MonoBehaviour {
	
	public float lightTime;
	public float maxTime;
	public float deplationTime;
	public GameObject AreaLight;
	public GameObject MainCharacter;
	public GUITexture flCurrentTex;
	MainCharRandomMov mScript;
	LightEffects lScript;
	
	// Use this for initialization
	void Start () {
		mScript = MainCharacter.GetComponent<MainCharRandomMov>();
		lScript = AreaLight.GetComponent<LightEffects>();

	}
	
	// Update is called once per frame
	void Update () {

		if(lightTime <= maxTime && lightTime >= 1)
		{
			lightTime -= deplationTime * Time.deltaTime;
			flCurrentTex.pixelInset = new Rect(90,14-(maxTime-lightTime),40,70);
			//Debug.Log (lightTime);
		}
		if(lightTime <= 1)
		{
			mScript.flashlightRun = false;
			lScript.intensityMultiplier = 0;
			
		}
	}
	
	
}
