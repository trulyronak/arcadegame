using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour {

    float time = 1.5f; // How long we're gonna be here + txt time on screen
    string nextScene = "Transition";
    Text blowup;
	// Use this for initialization
	void Start () {
        // Text
        // Canvas canvas = GetComponent<Canvas>();
        blowup = GameObject.Find("DisplayText").GetComponent<Text>();
        // blowup = GetComponent<Canvas>().GetComponent<Text>();

        // Game Logic
        
        if (Main.status == "from-menu")
        {
            Main.status = "from-transition";
            nextScene = (Main.games[Random.Range(0, Main.games.Length)]);
            // delete selected game
            blowup.text = nextScene;
        }
        else if (Main.status == "win-mg")
        {
            Main.gamesWon++;

            if (Main.gamesWon == 3)
            {
                blowup.text = "BOSS LVL";
                // they are ready for boss / final
            }
            else
            {
                Main.status = "from-transition";
                nextScene = (Main.games[Random.Range(0, Main.games.Length)]);
                blowup.text = nextScene;
            }
        }
        else if (Main.status == "lose-mg")
        {
            Main.status = "lost";
            blowup.text = "YOU LOSE";
            nextScene = "Main";
        }
        else
        {
            blowup.text = "TESTING AY";
        }

        
        blowup.fontSize = 0;

    }

    // Update is called once per frame
    void Update () {
        time -= Time.deltaTime;
        if (blowup.fontSize < 100)
            blowup.fontSize++;
        if (time > 0)
        {
            blowup.fontSize++;
        }
	    if (time < 0)
        {
            SceneManager.LoadScene(nextScene);
        }	
	}
}
