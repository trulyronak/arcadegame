using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowsMove : MonoBehaviour {

    public float secondsPressed;
    public float timer;
 
    private List<int> randPost = new List<int>(new int[] {-5, -1, 3}); //    private List<int> randPost = new List<int>(new int[] { -9, -5, -1, 3, 7 });


    private float timePressed;
    private float time;
    private float targetTime;

    private float gameTime = 6.0f;

    bool left, right, _left, _right = false;
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
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) {
            if (transform.position.x == randPost[GlassesMovement.randNum]) {
                Main.status = "win-mg";
            } else {
                Main.status = "lose-mg";
            }
            SceneManager.LoadScene("Transition");
        }
        if (!_left) {
            left = -Input.GetAxis("Horizontal") < 0;
        }
        _left = -Input.GetAxis("Horizontal") < 0;
        //left = Input.GetKeyDown("left") || Input.GetAxis("Horizontal") < 0;
        if (!_right) {
            right = -Input.GetAxis("Horizontal") > 0;
        }
        _right = -Input.GetAxis("Horizontal") > 0;
        //right = Input.GetKeyDown("right") || Input.GetAxis("Horizontal") > 0;

        if (left) {
            moveLeft();
        }
        if (right) {
            moveRight();
        }
        left = false;
        right = false;
        /*
        if (Input.GetKey("left") || Input.GetKey("right")) {
            if (left || right) {
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
        }*/
	}
    
    void moveRight() {
        if (transform.position.x == 3) {
            transform.Translate(-8, 0, 0);
        }
        else {
            transform.Translate(4, 0, 0);
        }
    }
    void moveLeft() {
        if (transform.position.x == -5) {
            transform.Translate(8, 0, 0);
        }
        else {
            transform.Translate(-4, 0, 0);
        }
    }
}
