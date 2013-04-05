using UnityEngine;
using System.Collections;

public class ClosestDisItem : MonoBehaviour {
	
	public GameObject Item1;
	public GameObject Item2;
	public GameObject Item3;
	public GameObject Item4;
		public GameObject Item5;
		public GameObject Item6;
		public GameObject Item7;
	public GUITexture gozKapagi;
	
	ItemScript mScript1;
	ItemScript mScript2;
	ItemScript mScript3;
	ItemScript mScript4;
	ItemScript mScript5;
	ItemScript mScript6;
	ItemScript mScript7;
	
	public float Distance;
	
	// Use this for initialization
	void Start () {
		mScript1 = Item1.GetComponent<ItemScript>();
		mScript2 = Item2.GetComponent<ItemScript>();
		mScript3 = Item3.GetComponent<ItemScript>();
		mScript4 = Item4.GetComponent<ItemScript>();
			mScript5 = Item5.GetComponent<ItemScript>();
		mScript6 = Item6.GetComponent<ItemScript>();
		mScript7 = Item7.GetComponent<ItemScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//int[] numbers = new int[5] {1, 2, 3, 4, 5};

		float[] ItemList = new float[7] { mScript1.distanceToChar, mScript2.distanceToChar, mScript3.distanceToChar, mScript4.distanceToChar, mScript5.distanceToChar, mScript6.distanceToChar, mScript7.distanceToChar};
		
		if ( Item1 == null )
		{
			ItemList[0] = 150000;
		}
		
		if ( Item2 == null )
		{
			ItemList[1] = 150000;
		}
		if ( Item3 == null )
		{
			ItemList[2] = 150000;
		}
		if ( Item4 == null )
		{
			ItemList[3] = 150000;
		}
		if ( Item5 == null )
		{
			ItemList[4] = 150000;
		}
		if ( Item6 == null )
		{
			ItemList[5] = 150000;
		}
		if ( Item7 == null )
		{
			ItemList[6] = 150000;
		}
		
		
		
//		ItemList..Sort();
		
		float min = 1500000;
		for( int i = 0; i < 7; i++ )
		{
			if( min > ItemList[i] )
				min = ItemList[i];
		}
		
		Distance = min;
		//Debug.Log(Distance);
		if(min <= 1500)
		{ 	
		gozKapagi.pixelInset = new Rect(0,500+(2500/Distance),100,100);
		}
	}
}
