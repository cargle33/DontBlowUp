﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour {

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
