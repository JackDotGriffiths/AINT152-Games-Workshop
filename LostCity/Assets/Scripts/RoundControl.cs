using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : MonoBehaviour {
    public static int DefaultZombies = 6;
    public static int ZombiesAmountToSpawn = 6;
    public static int ZombiesSpawned = 0;
    public static int ZombiesKilled;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        ZombiesAmountToSpawn = DefaultZombies;
	}
	
	// Update is called once per frame
	void Update () {
		if (ZombiesSpawned == ZombiesAmountToSpawn && ZombiesKilled == ZombiesSpawned)
        {
            audio.Play();
            GameUI.currentRound = GameUI.currentRound + 1;
            ZombiesKilled = 0;
            ZombiesSpawned = 0;
            ZombiesAmountToSpawn = DefaultZombies + (2 * GameUI.currentRound);
        }

	}
}
