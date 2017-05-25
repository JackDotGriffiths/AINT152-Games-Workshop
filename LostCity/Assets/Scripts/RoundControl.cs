using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : MonoBehaviour {
    public int DefaultZombies = 12;
    public static int ZombiesAmountToSpawn = 6;
    public static int ZombiesSpawned = 0;
    public static int ZombiesKilled = 0;
    public AudioSource audio;


    public bool Paused = false;

    // Use this for initialization
    void Start () {
        ZombiesAmountToSpawn = DefaultZombies;
        ZombiesSpawned = 0;
        ZombiesKilled = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ZombiesSpawned == ZombiesAmountToSpawn && ZombiesKilled == ZombiesSpawned)
        {
            audio.Play();
            GameUI.currentRound = GameUI.currentRound + 1;
            ZombiesKilled = 0;
            ZombiesSpawned = 0;
            ZombiesAmountToSpawn = DefaultZombies + (3 * GameUI.currentRound);
        }
	}

    private void OnGUI()
    {
        if (Paused == true)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.font = (Font)Resources.Load("Bebas");
            style.fontSize = 35;
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "PAUSED", style);
        }
    }
}
