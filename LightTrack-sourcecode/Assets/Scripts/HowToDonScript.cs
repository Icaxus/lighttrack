using UnityEngine;
using System.Collections;

public class HowToDonScript : MonoBehaviour {
	public GameObject mainCam;	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
void OnMouseDown() {
	
	mainCam.animation.Play("howtoDonAnim");
	}
}
