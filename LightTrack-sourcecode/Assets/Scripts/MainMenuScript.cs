using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public GUISkin customSkin1;
    public GUISkin customSkin2;
    public Texture2D headerTexture;
    public Texture2D newGameImage;
    public Texture2D howToPlayImage;
    public Texture2D creditsImage;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
    }


	void OnGUI() {
		
        GUI.skin = customSkin1;

        if (GUI.Button(new Rect(710, 325, 200, 100), ""))
        {
            Application.LoadLevel("OpeningScene");
        }
        if (GUI.Button(new Rect(710, 450, 200, 100), ""))
        {
            //Application.LoadLevel(4);
        }

	}

}

