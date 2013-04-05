using UnityEngine;
using System.Collections; 
 
public class CharBreatheAudio : MonoBehaviour { 
	 
	public GameObject mainChar; 
	MainCharRandomMov mScript; 
	 
	float WaitTime = 0.5f; 
	 
	public int breatheAudioVol = 3000; 
	// Use this for initialization 
	void Start () { 
		mScript = mainChar.GetComponent<MainCharRandomMov>(); 
		StartCoroutine(BreatheAudio()); 
		this.audio.volume = 0; 
	} 
	 
	// Update is called once per frame 
	void Update () { 
	} 
	 
	 
	IEnumerator BreatheAudio() { 
		 
		while(true) 
		{ 
			if( mScript.Fear >= 1000 ) 
				this.audio.volume = 0; 
			else 
				this.audio.volume = mScript.Fear/breatheAudioVol; 
			 
			yield return new WaitForSeconds(WaitTime); 
		} 
	} 
	 
	 
} 