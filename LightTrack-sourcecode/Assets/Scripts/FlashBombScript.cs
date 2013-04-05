using UnityEngine;
using System.Collections;

public class FlashBombScript : MonoBehaviour
{

    public GameObject MainCamera;
    FlashlightScript mScript;

    public bool flashBombIsActive = false;
    public float flashDur = 1.5f;

    // Use this for initialization
    void Start()
    {
        mScript = MainCamera.GetComponent<FlashlightScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mScript.lightTime);

        if (flashBombIsActive)
        {
            if (Random.value <= 0.3) //a random chance
            {
                if (this.light.enabled == true) //if the light is on...
                {
                    this.light.enabled = false; ; //turn it off
                }
                else
                {
                    this.light.enabled = true; //turn it on
                }
            }
        }
        else this.light.enabled = false;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1) && !flashBombIsActive)
        {
            if ((mScript.lightTime > mScript.maxTime * 0.25f))
            {
                flashBombIsActive = true;
                StartCoroutine(FlashBombDuration());
                //Debug.Log(mScript.lightTime);
                mScript.lightTime = mScript.lightTime - mScript.maxTime * 0.25f;
                //Debug.Log(mScript.lightTime);

                this.audio.Play();
            }
        }
    }

    IEnumerator FlashBombDuration()
    {
        yield return new WaitForSeconds(flashDur);
        flashBombIsActive = false;
    }
}