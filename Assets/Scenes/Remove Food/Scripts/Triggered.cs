using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
}

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "quad") {
            if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) {
                Destroy(col.gameObject);
            }
        }
    }

}
