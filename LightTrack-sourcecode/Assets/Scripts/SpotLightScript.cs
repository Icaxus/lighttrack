using UnityEngine;
using System.Collections;

public class SpotLightScript : MonoBehaviour {


    public GameObject MainCamera;
    FlashlightScript mScript;
	// Use this for initialization
	void Start () {
        mScript = MainCamera.GetComponent<FlashlightScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mScript.lightTime <= 0)
        {
            this.light.active = false;
        }
        else this.light.active = true;
	}
}
