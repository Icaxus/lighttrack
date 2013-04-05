using UnityEngine;
using System.Collections;

public class FlashHeal : MonoBehaviour {
	
	public GameObject mainChar;
	public GameObject mainCamera;
    public GameObject mainLight;
    public GameObject healLight;

    LightEffects mLightEffects;
	MainCharRandomMov mCharScript;
	FlashlightScript  mFlashScript;

	
	bool isHeal;
	
	// Use this for initialization
	void Start () {
		mCharScript = mainChar.GetComponent<MainCharRandomMov>();
		mFlashScript = mainCamera.GetComponent<FlashlightScript>();
	    mLightEffects = mainLight.GetComponent<LightEffects>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Input.GetMouseButtonDown(0) )
		{
		    mLightEffects.intensityMultiplier = 8.0f;
		    mainLight.light.color = Color.yellow;
		    healLight.light.enabled = true;
		    isHeal = true;
            healLight.audio.Play();
                

		}

		if( Input.GetMouseButtonUp(0) )
		{
            mLightEffects.intensityMultiplier = 6.5f;
		    mainLight.light.color = Color.white;
		    healLight.light.enabled = false;
		    isHeal = false;
            healLight.audio.Stop();
		}

		
	}
	
	void OnTriggerStay(Collider other)
	{
		
		if( other.CompareTag("MainCharacter") && isHeal )
		{
			mCharScript.Fear -= 15 * Time.deltaTime;
			mFlashScript.lightTime -= 3 * Time.deltaTime;
		}
		
	}
	
}
