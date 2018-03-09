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
                print("gameTime: " + gameTime);
                print("Score from remove food: " + (((5.0f - gameTime) / 5.0f) * 10.0f));
                Main.addScore(gameTime, 5.0f);
                // Main.score += ((5.0f - gameTime) / 5.0f) * 10.0f;
                Main.status = "win-mg";
                SceneManager.LoadScene("Transition");
            }
        }
    }

}
