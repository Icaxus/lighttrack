using UnityEngine;
using System.Collections;

public class StoryScript : MonoBehaviour {
	public GameObject mainCam;	
	bool startSt = false;
	public string animName;
	int timer = 0;
	bool say = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && startSt && mainCam.animation["StoryAnim"].speed != 0)	
		{
			mainCam.animation[animName].speed = 0;
		}
		else if(Input.GetMouseButtonDown(0) && startSt && mainCam.animation["StoryAnim"].speed == 0)	
		{
			mainCam.animation[animName].speed = 1;
		}
		if(say)
		{
			timer++;
			if(timer>=60)
			{
				startSt= true;
				say = false;
			}
		}
	}
	void OnMouseDown() {
		//Debug.Log ("asdaf");
		say = true;
		
		mainCam.animation.Play (animName	);
		
       
    }
}
