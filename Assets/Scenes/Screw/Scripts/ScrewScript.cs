using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrewScript : MonoBehaviour {
    private string state = "left";
    private int point = 0;

    private float gameTime = 10.0f;

    private bool left, up, right, down = false;
    // Use this for initialization
    void Start() {

    }
    void win() {
        if (point == 16){
            state = null;
            Main.status = "win-mg";
            SceneManager.LoadScene("Transition");
        }

    }
        // Update is called once per frame
    void Update() {
        left = -Input.GetAxis("Horizontal") < 0;
        up = Input.GetAxis("Vertical") > 0;
        right = -Input.GetAxis("Horizontal") > 0;
        down = Input.GetAxis("Vertical") < 0;
        gameTime -= Time.deltaTime;
        if (gameTime < 0) {
            Main.status = "lose-mg";
            SceneManager.LoadScene("Transition");
        }

        if (left && state == "left") {
            transform.Rotate(new Vector2(0, 100));
            transform.Translate(0, -.25f, 0);
            state = "up";
            point += 1;
        }
        if (up && state == "up") {
            transform.Rotate(new Vector2(0, 100));
            transform.Translate(0, -.25f, 0);
            state = "right";
            point += 1;
        }
        if (right && state == "right") {
            transform.Rotate(new Vector2(0, 100));
            transform.Translate(0, -.25f, 0);
            state = "down";
            point += 1;
        }
        if (down && state == "down")
        {
            transform.Rotate(new Vector2(0, 100));
            transform.Translate(0, -.25f, 0);
            state = "left";
            point += 1;
        }
        win();
        print(point);
    }
}
