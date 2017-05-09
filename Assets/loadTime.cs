using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadTime : MonoBehaviour {
	public Text lapTime;

	// Use this for initialization
	void Start () {
		float bestTime = PlayerPrefs.GetFloat ("Fastest Lap");
		if (bestTime > 0 ) {
			lapTime.text = "Best Time:"  + bestTime.ToString ();
		} else {
			lapTime.text = "Best Time:";
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
