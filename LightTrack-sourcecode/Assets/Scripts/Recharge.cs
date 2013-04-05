using UnityEngine;
using System.Collections;

public class Recharge : MonoBehaviour
{

    public GameObject MainCamera;
    FlashlightScript mScript;



    public float rechargeRate = 5f;
    public float totalCharge = 50f;
    private Light lightFlicker;

    public float cooldown = 60f;

    public float maxCharge = 50f;
    // Use this for initialization
    void Start()
    {
        mScript = MainCamera.GetComponent<FlashlightScript>();
        lightFlicker = gameObject.GetComponentInChildren<Light>();
        //maxCharge = totalCharge;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Debug.Log(totalCharge);
            if (mScript.lightTime <= 69 && totalCharge > 0)
            {
                RandomLightFlicker();
                mScript.lightTime += rechargeRate * Time.deltaTime;
                totalCharge -= rechargeRate * Time.deltaTime;

                if (totalCharge <= 0)
                    StartCoroutine(ChargeCooldown());

            }
            else if (totalCharge > 0)
            {
                lightFlicker.enabled = true;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            if(totalCharge > 0)
            audio.Play();
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            if (totalCharge > 0)
                lightFlicker.light.enabled = true;
            audio.Stop();
        }
    }

    IEnumerator ChargeCooldown()
    {
        lightFlicker.enabled = false;
        audio.Stop();
        yield return new WaitForSeconds(cooldown);
        Debug.Log(totalCharge);
        lightFlicker.enabled = true;
        totalCharge = maxCharge;
    }

    void RandomLightFlicker()
    {
        //Debug.Log("random value"+Random.value);
        if (Random.value <= 0.3) //a random chance
        {
            if (lightFlicker.light.enabled == true) //if the light is on...
            {
                lightFlicker.light.enabled = false; //turn it off
            }
            else
            {
                lightFlicker.light.enabled = true; //turn it on
            }
        }
    }
}
