using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CameraMove : MonoBehaviour {

    // Use this for initialization
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Text text;

    private int logo;
    private bool win;
    private bool translated;
    private float x;

    private float timer;
    private float sceneTimer;
    void Start() {
        transform.Translate(Random.Range(-20, 20), 0, 0);
        logo = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[logo];

        win = false;
        translated = false;

        timer = 6;
        sceneTimer = 2;
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            transform.Translate(0.2f * Input.GetAxis("Horizontal"), 0, 0);

            if (transform.position.x < 161.5f) {
                transform.Translate(202.7f - 161.5f, 0, 0);
            }

            if (transform.position.x > 215.8f) {
                transform.Translate(174.6f - 215.8f, 0, 0);
            }

            if (Input.GetButtonDown("Fire1")) {
                x = transform.position.x;
                if (logo == 0 && (Mathf.Abs(x - 174.5f) < 4 || Mathf.Abs(x - 215.5f) < 4) ||
                    logo == 1 && Mathf.Abs(x - 194.3f) < 4 ||
                    logo == 2 && Mathf.Abs(x - 184.1f) < 4 ||
                    logo == 3 && (Mathf.Abs(x - 163.7f) < 4 || Mathf.Abs(x - 204.8f) < 4)) {
                    win = true;
                } else {
                    timer = 0;
                }
            }
            timer -= Time.fixedDeltaTime;
        }

        if (timer < 0 || win) {
            x = transform.position.x;
            if (logo == 0 && (Mathf.Abs(x - 174.5f) < 4 || Mathf.Abs(x - 215.5f) < 4) ||
                logo == 1 && Mathf.Abs(x - 194.3f) < 4 ||
                logo == 2 && Mathf.Abs(x - 184.1f) < 4 ||
                logo == 3 && (Mathf.Abs(x - 163.7f) < 4 || Mathf.Abs(x - 204.8f) < 4)) {
                win = true;
            }
            if (win) {
                timer = 0;
                text.text = "O";
                text.color = Color.green;
                if (!translated) {
                    text.transform.Translate(-0.35f, 0, 0);
                    translated = true;
                }
            }
            text.enabled = true;
            sceneTimer -= Time.fixedDeltaTime;
        }

        if (sceneTimer < 0) {
            //SceneManager.LoadScene(1);//replace with transition scene
            Main.status = (win) ? "win-mg" : "lose-mg";
            SceneManager.LoadScene("Transition");
        }
	}
}