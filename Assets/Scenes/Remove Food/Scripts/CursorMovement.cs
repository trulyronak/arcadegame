using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {

    public GameObject bonelessPizza;
	void Start () {
        bonelessPizza.tag = "quad";
        bonelessPizza.transform.Translate(Random.Range(-5f, 5f), Random.Range(-4f, 4f), 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Main.GetAxis("Horizontal") * Time.deltaTime * 6, 0f, 0f);
        transform.Translate(0f, Main.GetAxis("Vertical") * Time.deltaTime * 6, 0f);
    }
}
