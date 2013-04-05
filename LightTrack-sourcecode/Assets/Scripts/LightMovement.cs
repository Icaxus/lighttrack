using UnityEngine; 
using System.Collections;

public class LightMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

		
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
			
		float horizontalSpeed = 2.0F;
    	float verticalSpeed = 2.0F;

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        this.transform.Translate(h, 0, v, Space.World);

		if( Input.GetKeyDown (KeyCode.L) )
		{
			Screen.lockCursor = !Screen.lockCursor;
		}
		
	}
}
