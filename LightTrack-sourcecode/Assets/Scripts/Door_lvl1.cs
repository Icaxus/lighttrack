using UnityEngine;
using System.Collections;

public class Door_lvl1 : MonoBehaviour
{

    public float DoorDuration = 1f;
    public GameObject DoorCamera_lvl1;
    public GameObject MainCamera;

    private Animation doorOpen;
    private Collider doorCollider;
	// Use this for initialization
	void Start ()
	{
	    doorOpen = GetComponentInChildren<Animation>();
        doorCollider = GetComponentInChildren<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MainCharacter"))
        {
            //StartCoroutine(DoorDur());
            //this.collider.gameObject.active = false;
            doorCollider.gameObject.active = false;
            doorOpen.Play();


        }
    }



    //IEnumerator DoorDur()
    //{
 
    //    //DoorCamera_lvl1.camera.enabled = true;
    //    //yield return new WaitForSeconds(2f);
    //    //Debug.Log("la");
    //    //MainCamera.camera.enabled = false;
    //}
}
