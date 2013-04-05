using UnityEngine;
using System.Collections;

public class TrapDmg : MonoBehaviour {
	
	MainCharRandomMov mScript;
	// Use this for initialization
	void Start () {
		mScript = GetComponent<MainCharRandomMov>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.name);
		if(other.CompareTag("Trap"))
		{
			mScript.Fear += 100f;
			mScript.grabTrap = true;
		}
	}
}
