using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timerScript : MonoBehaviour {

	float time = 0;
	float startTime  = 0;
	float bestLap = Mathf.Infinity;
	public Text lapTimer;
	public Text bestTime;
	float loadedTime; 
	public GameObject PickUp;
	public GameObject PickUp2;
	public GameObject PickUp3;
	public GameObject PickUp4;
	public GameObject PickUp5;
	public GameObject PickUp6;
	public GameObject PickUp7;
	public GameObject Pickup8;
	public GameObject Pickup9;


	void Awake(){
		loadedTime = PlayerPrefs.GetFloat ("Fastest Lap");
	}

	void Update(){
		time += Time.deltaTime;
		lapTimer.text ="Lap:" + time.ToString();
		if(loadedTime < bestLap) {
			bestTime.text = "Best: " + loadedTime.ToString ();
		} else if (bestLap == Mathf.Infinity) {
			bestTime.text = "Best: 0:00";
		} else {
			bestTime.text ="Best: " + bestLap.ToString ();
		}

		
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "ColliderBody") {
			if (time <= bestLap) {
				bestLap = time;
				//Sanity check so we don't get absurdly fast times saved
				if (bestLap > 35) {
					
					PlayerPrefs.SetFloat ("Fastest Lap", bestLap);
				}

			}
			Debug.Log (time-startTime);
			startTime = 0;
			time = 0;

			PickUp.SetActive (true);
			PickUp2.SetActive (true);
			PickUp3.SetActive (true);
			PickUp4.SetActive (true);
			PickUp5.SetActive (true);
			PickUp6.SetActive (true);
			PickUp7.SetActive (true);
			Pickup8.SetActive (true);
			Pickup9.SetActive (true);
			//other.gameObject.SetActive (true);
		}
	}
	}
