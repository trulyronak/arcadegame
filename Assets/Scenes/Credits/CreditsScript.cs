using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

	
	
public class CreditsScript : MonoBehaviour {
	private float creditTime = 7.0f;

	// Use this for initialization
	void Start () {
		
	}
	void Update () {
		creditTime -= Time.deltaTime;	
		print("Time: " + creditTime);
		if (creditTime < 0) {
			SceneManager.LoadScene("Main");
		}
	}
}
