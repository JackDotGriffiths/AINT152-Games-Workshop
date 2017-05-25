using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStaticVar : MonoBehaviour {

    // Use this for initialization
    void Start () {
        BuyDoor.Area2Open = false;
        BuyDoor.Area3Open = false;
        BuyDoor.Area4Open = false;
        BuyDoor.Area5Open = false;

        AreaSpawnerControl.Spawner3Active = false;
        AreaSpawnerControl.Spawner4Active = false;
        AreaSpawnerControl.Spawner5Active = false;
        AreaSpawnerControl.Spawner6Active = false;
        AreaSpawnerControl.Spawner7Active = false;
        AreaSpawnerControl.Spawner8Active = false;
        AreaSpawnerControl.Spawner9Active = false;
        AreaSpawnerControl.Spawner10Active = false;
        AreaSpawnerControl.Spawner11Active = false;
        AreaSpawnerControl.Spawner12Active = false;

        ShootBullet.fireTime = 1f;

        RoundControl.ZombiesAmountToSpawn = 6;
        RoundControl.ZombiesSpawned = 0;
        RoundControl.ZombiesKilled = 0;



        GameUI.Pistol.CurrentMag = 0;
        GameUI.Pistol.RemainingAmmo = 120;
        GameUI.Pistol.GunCapacity = 120;

        GameUI.Shotgun.CurrentMag = 0;
        GameUI.Shotgun.RemainingAmmo = 200;
        GameUI.Shotgun.GunCapacity = 200;
        GameUI.Shotgun.Unlocked = false;

        GameUI.Automatic.CurrentMag = 0;
        GameUI.Automatic.RemainingAmmo = 320;
        GameUI.Automatic.GunCapacity = 320;
        GameUI.Automatic.Unlocked = false;

        GameUI.Rocket.CurrentMag = 0;
        GameUI.Rocket.RemainingAmmo = 8;
        GameUI.Rocket.GunCapacity = 8;
        GameUI.Rocket.Unlocked = false;

        GameUI.Rifle.CurrentMag = 0;
        GameUI.Rifle.RemainingAmmo = 200;
        GameUI.Rifle.GunCapacity = 200;
        GameUI.Rifle.Unlocked = false;


        GameUI.currentRound = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
