using UnityEngine;
using System.Collections;

public class MouseClickForScenes : MonoBehaviour {
	
	public string gidilecekScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel(gidilecekScene);
		}
	}
}
