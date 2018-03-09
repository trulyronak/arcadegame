using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
public class Main : MonoBehaviour
{
    public static string status;
    public static List<string> games = new List<string>();
    public static int gamesWon;
    public static bool arcadeCabinetMode = false;
    public static float score = 0.00f;

    private void Start()
    {
        score = 0.00f; // reset the score
        gamesWon = 0;
        status = "menu";
        games.Add("Protect");
        games.Add("Tighten");
        games.Add("Remove-Food");
        games.Add("Climb");
        games.Add("Scout");
        //games = new string[5] { "Protect", "Tighten", "Remove-Food", "Climb", "Scout"}; //{ "Protect", "Climb", "Scout", "Remove-Food", "Inspire", "Screw" };
    }
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.B)) {
                Main.arcadeCabinetMode = !Main.arcadeCabinetMode;
                string text = "Arcade Cabinet Mode is " + ((Main.arcadeCabinetMode ? "activated" : "deactivated"));
                EditorUtility.DisplayDialog(text,"If you don't know what this means, deactivate it", "OK");

            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))
            {
                Debug.Log("at the menu");
                status = "from-menu";
                TextEnlarger.resetTime();
                SceneManager.LoadScene("Transition");
            }
        }
    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        System.Array.Resize(ref arr, arr.Length - 1);
    }

    public static float GetAxis(string axisName) {
        if (axisName == "Horizontal") {        
            if (arcadeCabinetMode) {
                return -Input.GetAxis(axisName);
            }
            else {
                return Input.GetAxis(axisName);
            }
        }
        else {
            return Input.GetAxis(axisName);
        }
    }

    public static void addScore(float timeUsed, float timeAllotted) {
        Main.score += ((timeAllotted - timeUsed) / timeAllotted) * 10.0f;
    }
}
