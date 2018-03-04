using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Triggered : MonoBehaviour {
    // Use this for initialization
    private float gameTime = 5.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        if (gameTime < 0)
        {
            Main.status = "lose-mg";
            SceneManager.LoadScene("Transition");
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "quad") {
            if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) {
                Main.status = "win-mg";
                SceneManager.LoadScene("Transition");
            }
        }
    }

}
