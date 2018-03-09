using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Climbing : MonoBehaviour {
    private int points;
    public float num;
    bool up = false;
    private float gameTime = 10.0f;

	// Use this for initialization
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

        up = Input.GetKey("up") || Main.GetAxis("Vertical") > 0;

        if (up && (Input.GetKeyUp("space") || Input.GetButtonDown("Fire1"))) {
            points += 1;
            // Debug.Log(points);
            transform.Translate(new Vector3(0, num, 0));
        }

        if (points == 9) {
            print("gameTime: " + gameTime);
            print("Score from climb: " + (((10.0f - gameTime) / 10.0f) * 10.0f));
            //Main.score += ((10.0f - gameTime) / 10.0f) * 10.0f;
            Main.addScore(gameTime, 10.0f);
            Main.status = "win-mg";
            SceneManager.LoadScene("Transition");

        }
    }
}
