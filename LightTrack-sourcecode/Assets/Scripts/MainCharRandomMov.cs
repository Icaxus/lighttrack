using UnityEngine;
using System.Collections;

public class MainCharRandomMov : MonoBehaviour
{


    public float Fear = 100;
    public bool mainCharInLight = true; // True if it is in the lighted area(Adjust according to LightCollider.cs)
    public int toplanacakObjeSayisi = 7;
    public int toplananObjeSayisi = 0;
    public bool flashlightRun = true;
    public bool grabTrap = false;
    public string gecilecekScene;
    public GUITexture mavi;
    public Vector2 randMoveRangeX = new Vector2(500, 1500); //Random Movement range in X axis
    public Vector2 randMoveRangeY = new Vector2(500, 1500); //Random Movement range in Y axis
    public float grabTimer = 0;

    public float monsterAttackRate = 0.5f;
    public float monsterDmg = 50f;

    public float speed = 5;
    public bool inAttack = false;
    public string stateDark; // State of the character in dark

    Light charLight;
    Vector3 dirPointInDark; // The random point in the map that the character tries to go in dark.

    public GameObject monsterHitAudio1;
    public GameObject monsterHitAudio2;
    public GameObject[] mainCharVoiceInDark;

    private int mainCharVoiceRandomNumber;

    // Use this for initialization
    void Start()
    {
        stateDark = "Rooming";
        mavi.pixelInset = new Rect(1, 1, 100, 0);

        charLight = this.GetComponentInChildren<Light>();
        monsterHitAudio1 = GameObject.Find("MonsterHitAudio1");
        monsterHitAudio1 = GameObject.Find("MonsterHitAudio2");
        mainCharVoiceInDark = GameObject.FindGameObjectsWithTag("MainCharVoiceInDark");

        StartCoroutine(MainCharVoiceInDark());
        //StartCoroutine(MonsterAttack());
    }

    // Update is called once per frame
    void Update()
    {
        //if(grabTrap)
        //{
        //    grabTimer += 1 * Time.deltaTime;
        //    if(grabTimer >= 3)
        //    {
        //        grabTimer = 0;
        //        grabTrap=false;
        //    }

        //}
        //Debug.Log("statedark" + stateDark);
        if (!flashlightRun)
        {
            mainCharInLight = false;
        }

        if (toplananObjeSayisi == toplanacakObjeSayisi)
        {
            Application.LoadLevel(gecilecekScene);
        }

        if (Fear >= 900)
        {

            Application.LoadLevel("GameOver");
        }


        if(toplanacakObjeSayisi == toplananObjeSayisi)
        {
            Application.LoadLevel("EndMenu");
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //inAttack = true;
            StartCoroutine("MonsterAttack");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //StopCoroutine("MonsterAttack");
            //inAttack = false;
            StopCoroutine("MonsterAttack");
        }
    }

    //	void OnTriggerStay(Collider other)
    //	{
    //		
    //		if(other.CompareTag("Enemy"))
    //		{
    //			 Fear = Fear + 2f; 
    // 
    //            Debug.Log("Fear" + Fear); 
    //		}
    //	}
    void FixedUpdate()
    {
        int ffear = (int)Fear;
        if (ffear <= 1000)
        {
            mavi.pixelInset = new Rect(0, 0, 100, ffear / 10f + 10);
        }


        if (!mainCharInLight)
        {
            //Debug.Log ("Not In light");

            charLight.intensity = 8;

            //Debug.Log("fdfsf:"+ffear);
            Fear += 2f; // Reducing fear in the dark
            //Debug.Log("Fear"+Fear);	
            switch (stateDark)
            {
                case "Rooming":
                    rooming();
                    break;
                case "DirSelect":
                    dirSelect();
                    break;
                case "FaceNewDir":
                    faceNewDir();
                    break;
            }
        }
        else
        {
            inLight();
        }
    }

    void dirSelect()
    {
        dirPointInDark = new Vector3(Random.Range(randMoveRangeX.x, randMoveRangeX.y), 0f, Random.Range(randMoveRangeY.x, randMoveRangeY.y));
        stateDark = "FaceNewDir";
    }

    void rooming()
    {

        Vector3 distance = new Vector3(dirPointInDark.x - this.transform.position.x,
                                        0f,
                                       dirPointInDark.z - this.transform.position.z);
        //dirPointInDark - this.transform.position;

        //Debug.Log (distance);

        if (distance.magnitude > speed * 5)
        {
            this.rigidbody.MovePosition(this.transform.position + distance.normalized * speed * Time.deltaTime);
            stateDark = "Rooming";
        }
        else
        {
            stateDark = "DirSelect";
        }

    }

    IEnumerator MainCharVoiceInDark()
    {
        while (true)
        {
            if (!mainCharInLight)
            {
                //Debug.Log("Darrrk");

                mainCharVoiceRandomNumber = Random.Range(0, 3);
                if (mainCharVoiceRandomNumber == 0)
                {
                    mainCharVoiceInDark[0].audio.Play();
                }
                else if (mainCharVoiceRandomNumber == 1)
                {
                    mainCharVoiceInDark[1].audio.Play();
                }
                else if (mainCharVoiceRandomNumber == 2)
                {
                    mainCharVoiceInDark[2].audio.Play();
                }
                else if (mainCharVoiceRandomNumber == 3)
                {
                    mainCharVoiceInDark[3].audio.Play();
                }
                yield return new WaitForSeconds(2.5f);
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    void faceNewDir()
    {
        Vector3 dir = dirPointInDark - this.transform.position;

        //Debug.Log (dir);

        this.transform.LookAt(dir);
        stateDark = "Rooming";
    }

    void inLight()
    {
        charLight.intensity = 1;
        //Debug.Log("alooooohaa");
    }


    IEnumerator MonsterAttack()
    {
        while (true)
        {
            Fear = Fear + monsterDmg;

            if (Random.Range(0, 1) == 1)
            {
                monsterHitAudio1.audio.Play();
            }
            else
            {
                monsterHitAudio2.audio.Play();
            }
            //Debug.Log("Fear" + Fear); 
            yield return new WaitForSeconds(1 / monsterAttackRate);
        }
    }

}
