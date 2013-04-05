using UnityEngine;
using System.Collections;

public class EnemyRandomMov : MonoBehaviour
{


    public bool enemyInLight = false; // True if it is in the lighted area(Adjust according to LightCollider.cs)
    public GameObject MainCharacter;
    public Vector2 randMoveRangeX = new Vector2(500, 1500); //Random Movement range in X axis
    public Vector2 randMoveRangeY = new Vector2(500, 1500); //Random Movement range in Y axis 
    MainCharRandomMov mScript;
    public float enemyInLightSpeed;
    public float enemyFleeLightSpeed;
    public float mainCharInLightSpeed;
    public float speed = 25;
    public float monsterRunTime = 1.5f;

    public GameObject MainCamera;

    public string stateDark; // State of the character in dark

    Vector3 dirPointInDark; // The random point in the map that the character tries to go in dark.

    bool flashBombIsActive = false;

    FlashlightScript mFlashScript;

    public GameObject FlashBombLight;
    FlashBombScript mBombScript;

    // Use this for initialization
    void Start()
    {
        enemyInLightSpeed = 15f;
        enemyFleeLightSpeed = 40f;
        mainCharInLightSpeed = 30f;
        stateDark = "DirSelect";
        mScript = MainCharacter.GetComponent<MainCharRandomMov>();
        mFlashScript = MainCamera.GetComponent<FlashlightScript>();
        mBombScript = FlashBombLight.GetComponent<FlashBombScript>();

        //        flashbombLight = GameObject.FindGameObjectWithTag("FlashbombLight");
        //        flashBombAudio = GameObject.FindGameObjectWithTag("FlashBombAudio");

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LightCollider") && mScript.mainCharInLight)
        {
            Kos();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightCollider"))
        {
            enemyInLight = false;
            stateDark = "DirSelect";
        }
    }

    void Kos()
    {
        if (flashBombIsActive == false)
        {
            //Debug.Log("flashBombIsActive" + "false");
            enemyInLight = true;
            Vector3 difference2 = MainCharacter.transform.position - this.transform.position;
            this.rigidbody.MovePosition(this.rigidbody.transform.position + difference2.normalized * enemyInLightSpeed * Time.deltaTime);
            this.rigidbody.transform.LookAt(difference2);
        }
        else
        {
            //Debug.Log("flashBombIsActive" + "true");
            enemyInLight = true;
            Vector3 difference2 = MainCharacter.transform.position - this.transform.position;
            this.rigidbody.MovePosition(this.rigidbody.transform.position - difference2.normalized * enemyFleeLightSpeed * Time.deltaTime);
            this.rigidbody.transform.LookAt(-difference2);
        }
    }

    void FixedUpdate()
    {
        flashBombIsActive = mBombScript.flashBombIsActive;

        if (!enemyInLight)
        {
            //Debug.Log ("Not In light");

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
    }

    void dirSelect()
    {
        dirPointInDark = new Vector3(Random.Range(randMoveRangeX.x, randMoveRangeX.y), 0f, Random.Range(randMoveRangeY.x, randMoveRangeY.y));
        stateDark = "FaceNewDir";
    }

    void rooming()
    {
        Vector3 distance = dirPointInDark - this.transform.position;

        //Debug.Log (distance);

        if (distance.magnitude > speed)
        {
            this.rigidbody.MovePosition(this.transform.position + distance.normalized * speed * Time.deltaTime);
            stateDark = "Rooming";
        }
        else
        {
            stateDark = "DirSelect";
        }

    }

    void faceNewDir()
    {
        Vector3 dir = dirPointInDark - this.transform.position;

        //Debug.Log(dir);

        this.transform.LookAt(dir);
        stateDark = "Rooming";
    }


}
