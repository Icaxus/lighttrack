using UnityEngine;
using System.Collections;

public class OpeningSceneScript : MonoBehaviour
{

    public GUITexture scene0;
    public GUITexture scene1;
    public GUITexture scene2;
    public GUITexture scene3;
    public GUITexture scene4;
    public GUITexture scene5;

    public GUITexture[] sceneArray;
    int sceneImageOrder = 1;
    int sceneImageCurrent;
    int sceneImageLast;
    

    // Use this for initialization
    void Start()
    {
        sceneArray = new GUITexture[6] {scene0, scene1, scene2, scene3, scene4, scene5};
        sceneImageLast = sceneArray.Length;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (sceneImageOrder > sceneImageLast-1)
            {
                Application.LoadLevel("FirstScene");
            }

            //Debug.Log("i:" + sceneImageOrder);
            sceneImageCurrent = sceneImageOrder;
            sceneArray[sceneImageOrder].pixelInset = new Rect(0, 0, 960, 600);
            for (int s = 0; s < sceneArray.Length; s++)
            {
                if (s != sceneImageCurrent)
                {
                    sceneArray[s].pixelInset = new Rect(-5000, -5000, 960, 600);
                }
            }

            //array out of range error'u cozulecek
            sceneImageOrder++;



        }

    }



}