using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesMovement : MonoBehaviour {

    // Use this for initialization
    private List<int> randPosition = new List<int>(new int[] { -4, 0, 4, 8, 12 });
    public static int randNum;
    void Start () {
        randNum = Random.Range(0, 5);
        transform.Translate(randPosition[randNum], 0, 0);
    }

    // Update is called once per frame
    void Update() {

    }
}
