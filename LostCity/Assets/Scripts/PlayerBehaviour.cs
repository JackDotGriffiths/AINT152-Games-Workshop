using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int health = 100;

    private Animator gunAnim;
    private Sprite newSprite;

    public Sprite Playerrifle;
    public Sprite Playershotgun;
    public Sprite Playerautomatic;
    public Sprite Playerrocket;
    public Sprite Playerpistol;

    public Texture DeadBackground;
    public Texture MainMenuButton;
    GUIStyle style = new GUIStyle();

    public bool Dead = false;
    public bool NewHighScore = false;
    public int Highscore;
   
    void Start()
    {
        Dead = false;
        SendHealthData();
        style.alignment = TextAnchor.MiddleCenter;
        style.imagePosition = ImagePosition.ImageAbove;
    }
    void Update()
    {
        if (GameUI.WeaponIndex == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Playerpistol;
        }
        else if (GameUI.WeaponIndex == 2)
        {
            GetComponent<SpriteRenderer>().sprite = Playershotgun;
        }
        else if (GameUI.WeaponIndex == 3)
        {
            GetComponent<SpriteRenderer>().sprite = Playerautomatic;
        }
        else if (GameUI.WeaponIndex == 4)
        {
            GetComponent<SpriteRenderer>().sprite = Playerrocket;
        }
        else if (GameUI.WeaponIndex == 5)
        {
            GetComponent<SpriteRenderer>().sprite = Playerrifle;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Dead = true;
        Highscore = PlayerPrefs.GetInt("Highscore");
        if (Highscore <= GameUI.currentRound)
        {
            NewHighScore = true;
            PlayerPrefs.SetInt("Highscore", GameUI.currentRound);
            PlayerPrefs.Save();
        }

    }
    void SendHealthData()
    { 
       OnUpdateHealth(health);
    }
    private void OnGUI()
    {
        if (Dead == true)
        {
            GUI.depth = 1;
            style.font = (Font)Resources.Load("Bebas");
            GUI.Box(new Rect((Screen.width / 2) - (900 / 2), (Screen.height / 2) - (508 / 2), 900,508), DeadBackground, style);
            GUI.depth = 0;
            style.fontSize = 55;
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 550, (Screen.width) / 4, (Screen.height) / 4), "Wave Reached: " + GameUI.currentRound.ToString(), style);
            if (NewHighScore == true)
            {
                GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 500, (Screen.width) / 4, (Screen.height) / 4), "New Highscore!", style);
            }
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 450, (Screen.width) / 4, (Screen.height) / 4), "Highscore: " + Highscore, style);

            Time.timeScale = 0;
            if (GUI.Button(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 300, (Screen.width) / 4, (Screen.height) / 4), MainMenuButton,style))
            {
                SceneManager.LoadSceneAsync("MainMenu");
                
            }

        }
    }
}
