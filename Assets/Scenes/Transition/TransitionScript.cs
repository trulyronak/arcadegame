using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour {

    float time = 1.5f; // How long we're gonna be here + txt time on screen
    string nextScene = "Transition";
    Text blowup;
    float overallTime = 0f;
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
            int newGame = Random.Range(0, Main.games.Count);
       
            nextScene = (Main.games[newGame]);
            Main.games.RemoveAt(newGame);
            //Main.RemoveAt(ref Main.games, newGame);
            //Main.games
            // delete selected game
            blowup.text = nextScene;
        }
        else if (Main.status == "win-mg")
        {
            Main.gamesWon = Main.gamesWon + 1;
            print("games won is " + Main.gamesWon);
            if (Main.gamesWon == 3)
            {
                blowup.text = "BOSS LVL";
                nextScene = "Build";
            }
            else
            {
                Main.status = "from-transition";
                int newGame = Random.Range(0, Main.games.Count);
                nextScene = (Main.games[newGame]);
                blowup.text = nextScene;
                Main.games.RemoveAt(newGame);
            }
        }
        else if (Main.status == "lose-mg")
        {
            Main.status = "lost";
            blowup.text = "YOU LOSE";
            nextScene = "Main";
        }
        else if (Main.status == "win-boss") {
            Main.status = "Menu";
            //int score = - Time.time
            blowup.text = "SCORE: too pro";
            nextScene = "Main";

        }
        else if (Main.status == "lose-boss")
        {
            Main.status = "Menu";
            blowup.text = "You tried";
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
