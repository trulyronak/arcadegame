using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextEnlarger : MonoBehaviour
{

    Text g;
    public Bobot b;
    int size = 0;
    int startime, score = 0;
    bool finished = false;
    float endGameTime = 5.0f;
    bool scoreSet = false;
    static int lastEndTime;
    void Start()
    {
        g = GetComponent<Text>();
        //b = GetComponent<Bobot>();
        g.fontSize = 0;
        startime = (int)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            endGameTime -= Time.deltaTime;
        }
        if (endGameTime < 0)
        {
            if (b.finishedBuild)
            {
                Main.status = ("win-boss");
            }
            else
            {
                Main.status = ("lose-boss");
            }
            Main.status = "done";
            // report high score
            SceneManager.LoadScene("Credits");
            // SceneManager.LoadScene("Main");
        }
        if (!finished && g.fontSize < 100) {
            g.fontSize++;
        }   
        else
        {
            int gametime = (int)Time.time - startime;
            g.text = gametime.ToString();

            if(b.finishedBuild)
            {
                finished = true;
                b.enabled = false;
                g.fontSize = 80;
                //int finalscore = 
                if (!scoreSet) {
                    Main.score += (int) (Mathf.Log((150 - ((int)Time.time - lastEndTime))) * 1000.0f);
                    Main.score += 20; // win bonus
                    Main.reportScore();
                    // PlayerPrefsX.
                    scoreSet = true;
                }
                g.text = "Dozer is finally happy :) ... Score: " + (Main.score).ToString();
                Dance();
                
            }
            else if(gametime > 30)
            {
                finished = true;
                b.enabled = false;
                g.fontSize = 80;
                if (!scoreSet) {
                    Main.score += (int) (Mathf.Log((150 - ((int)Time.time - lastEndTime))) * 1000.0f);
                    Main.reportScore();
                    scoreSet = true;
                }
                g.text = "You lose! Dozer is sad :( ... Score: " + Main.score.ToString();
            }
            else
            {
                print("Time: " + Time.time);
                print("Last End Time: " + lastEndTime);
                print("Usual Score: " + (150 - ((int)Time.time - lastEndTime)));
                // Main.score += ((150 - ((int)Time.time - lastEndTime)) / 160.0f) * 50.0f;//(((Time.time - lastEndTime) / 30.0f) * 10);
                // score = 150 - ((int)Time.time - lastEndTime);
            }
            //print(score.ToString());
            /*if (gametime > 10)
            {
                b.enabled = false;
                if (b.finishedBuild)
                {
                    g.text = "Dozer is finally happy...";
                    //enabled = false;
                    Dance();
                }
                else
                {
                    g.text = "You lose! Dozer is sad :(";
                    enabled = false;
                }
            }*/
        }
    }

    void Dance()
    {
        //print("in dance()");
        //while (!Input.anyKeyDown)
        //{
            //print("in while loop");
            //for (int i = 0; i < 360; i++)
            //{
                //print("in for loop");
                b.transform.Rotate(0, size, 0);
        size++;
            //}
        //}
    }

    public static void resetTime()
    {
        lastEndTime = (int)Time.time;
    }
}
