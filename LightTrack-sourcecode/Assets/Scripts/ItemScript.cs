using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{

    public GameObject MainCharacter;
    MainCharRandomMov mScript;
    public GUITexture doluObje;
    public GUITexture bosObje;
    public int yer;

    public float distanceToChar;
    // Use this for initialization
    void Start()
    {
        mScript = MainCharacter.GetComponent<MainCharRandomMov>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 disVec = this.transform.position - MainCharacter.transform.position;
        distanceToChar = disVec.magnitude;
        //Debug.Log (distanceToChar);

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log (other.tag);
        if (other.CompareTag("MainCharacter"))
        {
            doluObje.pixelInset = new Rect(25, yer * 50, 50, 50);
            bosObje.pixelInset = new Rect(-500, yer * 50, 50, 50);
            mScript.toplananObjeSayisi += 1;
            if (mScript.Fear >= 100)
            {
                mScript.Fear -= 100f;
            }
            //Debug.Log("Item Found Fear:"+mScript.Fear);

            //			audio mAudio = this.GetComponentInChildren<AudioClip>();
            //			mAudio.Play();

            //Destroy (this.gameObject);
            Capture();
            audio.Play();

        }
    }

    void Capture()
    {
        if (this.name == "Dudak")
        {
            this.transform.position = new Vector3(1111.722f, -148.5573f, 1303.783f);
            this.transform.rotation = Quaternion.identity;
            this.transform.localScale = new Vector3(2.8f, 2.8f, 0.0003f);
        }
        if (this.name == "Tabak")
        {
            this.transform.position = new Vector3(1111.5f, -151.9584f, 13000.463f);
            this.transform.rotation = Quaternion.identity;
            this.transform.localScale = new Vector3(3f, 3f, 0.0003f);
        }
        if (this.name == "Para")
        {
            this.transform.position = new Vector3(1117.432f, -149.3078f, 1301.93f);
            this.transform.rotation = Quaternion.identity;
            this.transform.localScale = new Vector3(3.2f, 4.2f, 0.0003f);
        }
        if (this.name == "Top")
        {
            this.transform.position = new Vector3(1112.5f, -151.2f, 1450.3f);
            this.transform.rotation = Quaternion.identity;
            this.transform.localScale = new Vector3(3f, 3f, 0.0003f);
        }
        if (this.name == "Kalem")
        {
            this.transform.position = new Vector3(1112.932f, -147.964f, 1450.603f);
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
            this.transform.localScale = new Vector3(2.5111f, 2.5111f, 0.0003f);
        }
        if (this.name == "Emzik")
        {
            this.transform.position = new Vector3(1117.535f, -149.4583f, 1450.6f);
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 160));
            this.transform.localScale = new Vector3(2f, 2f, 0.0003f);
        }
        if (this.name == "Cicek")
        {
            this.transform.position = new Vector3(1117.132f, -152.0804f, 1306.737f);
            this.transform.rotation = Quaternion.identity;
            this.transform.localScale = new Vector3(3f, 3f, 0.0003f);
        }
    }
}