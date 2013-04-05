using UnityEngine;
using System.Collections;

public class RandomYer : MonoBehaviour {

	public int rnmbx;
	public int rnmby;
	// Use this for initialization
	void Start () {
	
	rnmbx = UnityEngine.Random.Range(900, 1120);
		rnmby = UnityEngine.Random.Range(900, 1120);
	transform.Translate(rnmbx,70,rnmby);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
