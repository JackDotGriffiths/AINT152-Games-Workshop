using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public string Tag = " ";

    public bool Escaped = false;
    public bool NewHighScore = false;
    public int Highscore;
    public bool triggered = false;


    public Texture EscapedBackground;
    public Texture MainMenuButton;
    GUIStyle style = new GUIStyle();


    // Use this for initialization
    public void EscapeInitiate()
    {
        Escaped = true;
        Highscore = PlayerPrefs.GetInt("Highscore");
        if (Highscore <= GameUI.currentRound)
        {
            NewHighScore = true;
            PlayerPrefs.SetInt("Highscore", GameUI.currentRound);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        bool afford = false;
        if (GameObject.Find("UserInterface").GetComponent<GameUI>().score >= 25000)
        {
            afford = true;
        }
        if (Input.GetKeyDown("f") && triggered == true && afford == true)
        {
            GameObject.Find("UserInterface").GetComponent<GameUI>().score -= 25000;
            EscapeInitiate();
            Destroy(gameObject);
            afford = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            triggered = false;
        }
    }

    private void Start()
    {
        style.alignment = TextAnchor.MiddleCenter;
        style.imagePosition = ImagePosition.ImageAbove;
    }


    private void OnGUI()
    {

        if (triggered == true)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.font = (Font)Resources.Load("Bebas");
            style.fontSize = 35;
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "Press [F] to escape for £25000", style);
        }
        if (Escaped == true)
        {
            GUI.depth = 1;
            style.font = (Font)Resources.Load("Bebas");
            GUI.Box(new Rect((Screen.width / 2) - (900 / 2), (Screen.height / 2) - (508 / 2), 900, 508), EscapedBackground, style);
            GUI.depth = 0;
            style.fontSize = 55;
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 550, (Screen.width) / 4, (Screen.height) / 4), "Wave Reached: " + GameUI.currentRound.ToString(), style);
            if (NewHighScore == true)
            {
                GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 500, (Screen.width) / 4, (Screen.height) / 4), "New Highscore!", style);
            }
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 450, (Screen.width) / 4, (Screen.height) / 4), "Highscore: " + Highscore, style);

            Time.timeScale = 0;
            if (GUI.Button(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 300, (Screen.width) / 4, (Screen.height) / 4), MainMenuButton, style))
            {
                SceneManager.LoadSceneAsync("MainMenu");

            }

        }
    }
}    
