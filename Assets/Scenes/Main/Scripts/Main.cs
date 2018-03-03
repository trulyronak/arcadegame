using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    public static string status;
    public static string[] games;
    public static int gamesWon;

    private void Start()
    {
        gamesWon = 0;
        status = "menu";
        games = new string[5] { "Protect", "Screw", "Remove-Food", "Climb", "Scout"}; //{ "Protect", "Climb", "Scout", "Remove-Food", "Inspire", "Screw" };
    }
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))
            {
                Debug.Log("at the menu");
                status = "from-menu";
                SceneManager.LoadScene("Transition");
            }
        }
}
