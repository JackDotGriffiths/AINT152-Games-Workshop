using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {
    public string Tag = "";

    public AudioSource magReload;
    public AudioSource shotgunReload;
    public AudioSource rocketReload;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            if (GameUI.WeaponIndex == 1)
            {
                //Pistol
                magReload.Play();
                GameUI.Pistol.RemainingAmmo = 120;
            }
            if (GameUI.WeaponIndex == 2)
            {
                //Shotgun
                shotgunReload.Play();
                GameUI.Shotgun.RemainingAmmo = 200;
            }
            if (GameUI.WeaponIndex == 3)
            {
                //Automatic
                magReload.Play();
                GameUI.Automatic.RemainingAmmo = 320;
            }
            if (GameUI.WeaponIndex == 4)
            {
                //Rocket
                rocketReload.Play();
                GameUI.Rocket.RemainingAmmo = 8;
            }
            if (GameUI.WeaponIndex == 5)
            {
                //Rifle
                magReload.Play();
                GameUI.Rifle.RemainingAmmo = 200;
            }
            Destroy(gameObject);
        }
    }
}
