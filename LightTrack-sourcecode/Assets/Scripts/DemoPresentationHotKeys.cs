using UnityEngine;
using System.Collections;

public class DemoPresentationHotKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.E))
        {
            Application.LoadLevel("EndMenu");
        }
        if (Input.GetKey(KeyCode.M))
        {
            Application.LoadLevel("MainMenu");
        }
	}
}
