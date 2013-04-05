using UnityEngine;
using System.Collections;

public class LightCollider : MonoBehaviour
{

    public GameObject MainCharacter;
    public GameObject Enemy;
    public GameObject centerObject;
    MainCharRandomMov mScript;
    EnemyRandomMov mScript2;
    public float enemyInLightSpeed;
    public float mainCharInLightSpeed;

    // Use this for initialization
    void Start()
    {
        //MainCharacter = GameObject.FindGameObjectWithTag("MainCharacter");
        mScript = MainCharacter.GetComponent<MainCharRandomMov>();

        enemyInLightSpeed = 15f;
        mainCharInLightSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mScript.flashlightRun)
        {
            mScript.mainCharInLight = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter") && mScript.flashlightRun && !mScript.grabTrap)
        {
            mScript.mainCharInLight = true;
            mScript.stateDark = "InLight";
            //Debug.Log ("true");

            //Debug.Log("Collision VAR!");

            Vector3 difference = new Vector3(gameObject.transform.position.x - other.transform.position.x,
                                                0f,
                                             gameObject.transform.position.z - other.transform.position.z);

            if (difference.magnitude > 1)
                other.rigidbody.MovePosition(other.rigidbody.transform.position + difference.normalized * mainCharInLightSpeed * Time.deltaTime);

            //Debug.Log("difference.magn" + difference.magnitude);
            Vector3 pos;
            pos.x = centerObject.transform.position.x;
            pos.y = other.transform.position.y;
            pos.z = centerObject.transform.position.z;
            Vector2 v2Pos = new Vector2(pos.x, pos.z);
            Vector2 v2Other = new Vector2(other.transform.position.x, other.transform.position.z);

            Vector2 disToCenter = v2Pos - v2Other;

            //Debug.Log (disToCenter.magnitude); 

            if (disToCenter.magnitude > 1)
                other.transform.LookAt(pos);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            mScript.mainCharInLight = false;
            mScript.stateDark = "DirSelect";
        }


    }


}
