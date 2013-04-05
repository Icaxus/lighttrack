using UnityEngine;
using System.Collections;

public class DeadTrapScript : MonoBehaviour
{


    public GameObject MainChar;
    GameObject trapReOpenSound;
    MainCharRandomMov mScript;

    private float trapDur = 3.0f;
	// Use this for initialization
	void Start () {
        mScript = MainChar.GetComponent<MainCharRandomMov>();
        trapReOpenSound = GameObject.Find("TrapReOpenSound");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            animation["Take 001"].speed = 2f;
            animation.Play("Take 001");
            audio.Play();

            mScript.grabTrap = true;
            StartCoroutine(TrapDuration());

        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter") && mScript.grabTrap)
        {
            other.rigidbody.MovePosition(this.transform.position);
        }
    }


    void OnTriggerExit(Collider other)
    {

    }

    IEnumerator TrapDuration()
    {
        yield return new WaitForSeconds(trapDur);
        mScript.grabTrap = false;
        animation["Take 001"].speed = -1f;
        animation["Take 001"].time = animation["Take 001"].length;
        animation.Play("Take 001");
        trapReOpenSound.audio.Play();
    }
}


/*

*/