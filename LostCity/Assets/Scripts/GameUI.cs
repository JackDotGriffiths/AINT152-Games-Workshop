using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : MonoBehaviour {

    public int health;
    public int score;

    public  class Guns
    {
        public int CurrentMag;
        public int RemainingAmmo;
        public int GunCapacity;
        public bool Unlocked;
    }


    static public int WeaponIndex = 1;
    GUIContent content;
    GUIStyle style = new GUIStyle();

    GUIContent magContent;
    GUIContent remainingContent;

    private string gameInfo = "";
    public  Texture rifle;
    public Texture shotgun;
    public Texture automatic;
    public Texture rocket;
    public Texture pistol;
    public Texture GunBackground;
    public Texture ScoreBackContent;
    GUIContent UIBackcontent;
    private Rect boxRect = new Rect(10, 10, 300, 50);

    public static Guns Pistol = new Guns();
    public static Guns Shotgun = new Guns();
    public static Guns Automatic = new Guns();
    public static Guns Rocket = new Guns();
    public static Guns Rifle = new Guns();

    public static int currentRound = 1;



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
        //Retrieve mouse scroll if the user wishes to change weapon.
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
        UIBackcontent = new GUIContent("", GunBackground, "Display");
        style.alignment = TextAnchor.MiddleCenter;
        style.imagePosition = ImagePosition.ImageAbove;
   
        Pistol.CurrentMag = 0;
        Pistol.RemainingAmmo = 120;
        Pistol.GunCapacity = 120;

        Shotgun.CurrentMag = 0;
        Shotgun.RemainingAmmo = 200;
        Shotgun.GunCapacity = 200;

        Automatic.CurrentMag = 0;
        Automatic.RemainingAmmo = 320;
        Automatic.GunCapacity = 320;

        Rocket.CurrentMag = 0;
        Rocket.RemainingAmmo = 8;
        Rocket.GunCapacity = 8;

        Rifle.CurrentMag = 0;
        Rifle.RemainingAmmo = 200;
        Rifle.GunCapacity = 200;
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
        gameInfo = "Score:" + score.ToString();
    }
    void OnGUI()
    {
        UpdateUI();
        WeaponChangeBehaviour();
        style.font = (Font)Resources.Load("Bebas");
        GUI.depth = 1;
        //Background for Gun Display
        GUI.Box(new Rect(10, Screen.height - 100, 200, 80), UIBackcontent, style);
        //Background for Ammo Display
        GUI.Box(new Rect(Screen.width - 210, Screen.height - 100, 200, 80), UIBackcontent, style);
        //Background for Score Display
        GUI.Box(new Rect(Screen.width - 210, Screen.height - 160, 200, 80), ScoreBackContent, style);


        GUI.depth = 0;
        //Display the currently active gun.
        GUI.Box(new Rect(10, Screen.height - 100, 200, 80), content, style);
        //Display the mag ammo remaining.
        style.fontSize = 45;
        GUI.Box(new Rect(Screen.width - 210, Screen.height - 95, 100, 80), magContent, style);
        //Display total ammo remaining
        style.fontSize = 35;
        GUI.Box(new Rect(Screen.width - 210, Screen.height - 95, 250, 80), remainingContent, style);
        //Display current Score
        style.fontSize = 25; 
        GUI.Box(new Rect(Screen.width - 210, Screen.height - 157, 100, 80), gameInfo, style);
        //Display Current Round
        GUI.Box(new Rect(Screen.width / 2 - 50, 0, 100, 100), "Wave", style);
        style.fontSize = 45;
        GUI.Box(new Rect(Screen.width / 2 - 50, 27, 100, 100), currentRound.ToString(), style);
        style.fontSize = 25;
        GUI.Box(new Rect(0,0,200,50), "Zombies Remaining:" + (RoundControl.ZombiesAmountToSpawn - RoundControl.ZombiesKilled).ToString(), style);
    }
    public void WeaponChangeBehaviour()
    {
        if (WeaponIndex == 1)
        {
            //Pistol
            content = new GUIContent(pistol);
            magContent = new GUIContent(Pistol.CurrentMag.ToString());
            remainingContent = new GUIContent(Pistol.RemainingAmmo.ToString()); 
            ShootBullet.fireTime = 1f;
        }
        if (WeaponIndex == 2)
        {
            //Shotgun
            content = new GUIContent(shotgun);
            magContent = new GUIContent(Shotgun.CurrentMag.ToString());
            remainingContent = new GUIContent(Shotgun.RemainingAmmo.ToString());
        }
        if (WeaponIndex == 3)
        {
            //Automatic
            content = new GUIContent(automatic);
            magContent = new GUIContent(Automatic.CurrentMag.ToString());
            remainingContent = new GUIContent(Automatic.RemainingAmmo.ToString());
            ShootBullet.fireTime = 0.05f;
        }
        if (WeaponIndex == 4)
        {
            //Rocket
            content = new GUIContent(rocket);
            magContent = new GUIContent(Rocket.CurrentMag.ToString());
            remainingContent = new GUIContent(Rocket.RemainingAmmo.ToString());
        }
        if (WeaponIndex == 5)
        { 
            //Rifle
            content = new GUIContent(rifle);
            magContent = new GUIContent(Rifle.CurrentMag.ToString());
            remainingContent = new GUIContent(Rifle.RemainingAmmo.ToString());
        }
    }
    }

