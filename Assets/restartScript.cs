using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			Debug.Log("R pressed");
			SceneManager.LoadScene("firstScene");

		}
		else if (Input.GetKeyDown(KeyCode.M)){
			SceneManager.LoadScene("menuscreen");
		}
		
	}
}
