using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowsMove : MonoBehaviour {

    public float secondsPressed;
    public float timer;
 
    private List<int> randPost = new List<int>(new int[] { -9, -5, -1, 3, 7 });

    private float timePressed;
    private float time;
    private float targetTime;

    private float gameTime = 10.0f;
	// Use this for initialization
	void Start () {
        targetTime = timer;
    }

    // Update is called once per frame
    void Update () {
        gameTime -= Time.deltaTime;

        if (gameTime < 0) {
            Main.status = "lose-mg";
            SceneManager.LoadScene("Transition");
        }
        if (transform.position.x == randPost[GlassesMovement.randNum] && Input.GetKeyDown("space")) {
            print("Game Over");
            // game won yay
            Main.status = "win-mg";
            SceneManager.LoadScene("Transition");
        }
        if (Input.GetKeyDown("left")) {
            moveLeft();
        }
        if (Input.GetKeyDown("right")) {
            moveRight();
        }
        if (Input.GetKey("left") || Input.GetKey("right")) {
            if (Input.GetKeyDown("left") || Input.GetKeyDown("right")) {
                time = Time.time;
            }
            timePressed = Time.time - time;
        }
        if (timePressed > secondsPressed) {
            targetTime -= Time.deltaTime;
            if (targetTime < 0.0f) {
                targetTime = timer;
                if (Input.GetKey("left")) {
                    moveLeft();
                }
                if (Input.GetKey("right")) {
                    moveRight();
                }
            }
        }
	}
    void moveRight() {
        if (transform.position.x == 7) {
            transform.Translate(-16, 0, 0);
        }
        else {
            transform.Translate(4, 0, 0);
        }
    }
    void moveLeft() {
        if (transform.position.x == -9) {
            transform.Translate(16, 0, 0);
        }
        else {
            transform.Translate(-4, 0, 0);
        }
    }
}
