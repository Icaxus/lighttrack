using UnityEngine;
using System.Collections;

public class CharStepAudio : MonoBehaviour
{

    public string movementState; 	// 'Stopped' when char is not moving // 'Moving' when char is moving // 'StartMoving' when char just start to move 

    Animation animWalk;
    Vector3 prevPosition;
    float WaitTime = 0.1f;

    // Use this for initialization 
    void Start()
    {
        StartCoroutine(CheckState());
        animWalk = this.GetComponentInChildren<Animation>();
        animWalk.Play("Mov");
    }

    // Update is called once per frame 
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (movementState == "Stopped")
        {
            this.audio.Stop();
            //			if(!animWalk.IsPlaying("idle"))
            //				animWalk.Play("idle");
            //Debug.Log ("heey");
            animWalk["Mov"].speed = 0.0f;

            //animWalk.Stop ();
        }
        else if (movementState == "StartMoving")
        {
            this.audio.Play();
            //animWalk.Play ();

            //			if( animWalk.IsPlaying("Mov"))
            //				Debug.Log("YURUU");
            movementState = "Moving";
        }
        else if (movementState == "Moving")
        {
            animWalk["Mov"].speed = 1.0f;
            //Debug.Log (movementState); 
            //			if(!animWalk.IsPlaying("Mov"))
            //			{
            //				//animWalk.Play("Mov");
            //				//Debug.Log("YURUU");
            //			}
        }
    }


    IEnumerator CheckState()
    {

        while (true)
        {
            Vector2 diff = new Vector2(transform.position.x - prevPosition.x, transform.position.z - prevPosition.z);

            if (Mathf.Abs(diff.magnitude) < 1)
            {
                movementState = "Stopped";
            }
            else if (movementState == "Stopped")
            {
                movementState = "StartMoving";
            }

            //Debug.Log (movementState); 
            prevPosition = this.transform.position;

            yield return new WaitForSeconds(WaitTime);
        }
    }
}
