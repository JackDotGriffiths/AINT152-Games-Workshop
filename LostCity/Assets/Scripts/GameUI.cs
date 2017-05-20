using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private int health;
    private int score;
    public static int WeaponIndex = 1;
    GUIContent content;
    GUIStyle style = new GUIStyle();

    private string gameInfo = "";
    public  Texture rifle;
    public Texture shotgun;
    public Texture automatic;
    public Texture rocket;
    public Texture pistol;
    private Rect boxRect = new Rect(10, 10, 300, 50);



    void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }
    void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            WeaponIndex += 1;
            if (WeaponIndex == 5)
            {
                WeaponIndex = 1;
            }
            WeaponChangeBehaviour();

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            WeaponIndex -= 1;
            if (WeaponIndex == 0)
            {
                WeaponIndex = 6;
            }
            WeaponChangeBehaviour();

        }
    }
    void Start()
    {
        UpdateUI();
        content = new GUIContent("", pistol, "This is a tooltip");
        style.alignment = TextAnchor.MiddleCenter;
        style.imagePosition = ImagePosition.ImageAbove;
    }
    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }
    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }
    void UpdateUI()
    {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();
    }
    void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
        GUI.Box(new Rect(10, Screen.height - 100, 200, 80), content, style);
    }
    public void WeaponChangeBehaviour()
    {
        if (WeaponIndex == 1)
        {
            //Pistol
            content = new GUIContent("", pistol, "This is a tooltip");
        }
        if (WeaponIndex == 2)
        {
            //Shotgun
            content = new GUIContent("", shotgun, "This is a tooltip");
        }
        if (WeaponIndex == 3)
        {
            //Automatic
            content = new GUIContent("", automatic, "This is a tooltip");
        }
        if (WeaponIndex == 4)
        {
            //Rocket
            content = new GUIContent("", rocket, "This is a tooltip");
        }
        if (WeaponIndex == 5)
        
            //Rifle
            content = new GUIContent("", rifle, "This is a tooltip");
    }
    }

