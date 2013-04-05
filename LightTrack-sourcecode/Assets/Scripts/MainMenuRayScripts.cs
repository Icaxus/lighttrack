using UnityEngine;
using System.Collections;

public class MainMenuRayScripts : MonoBehaviour {
	
	public string gidilecekScene;
	public GameObject mainCam;
    //public GameObject mainMenuAudio;
	int timer = 0;
	bool say = false;
	// Use this for initialization
	void Start ()
	{

        //mainMenuAudio = GameObject.Find("MainMenuAudio");

	}
	
	// Update is called once per frame
	void Update () {
	    //mainMenuAudio.audio.Play();
		if(say)
		{
			timer++;
			if(timer>=60){
				 Application.LoadLevel(gidilecekScene);
				timer= 0;
			}
		}


	}
	void OnMouseDown() {
		//Debug.Log ("asdaf");
		say = true;
		mainCam.animation.Play ();
       
    }
	void OnMouseOver() {

    }
		void OnMouseExit() {
		
    }
	

}
