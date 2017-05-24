using UnityEngine;
using System.Collections;
public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public static float fireTime = 1f;
    private bool isFiring = false;
    private bool OutOfAmmo = true;

    public AudioSource gunShot;
    public AudioSource ammoClick;
    public AudioSource rocketFire;
    public AudioSource shotgunFire;

    public AudioSource magReload;
    public AudioSource shotgunReload;
    public AudioSource rocketReload;

    void SetFiring()
    {
        isFiring = false;
    }
    void Fire()
    {
        if (!HasAmmo())
        {
            isFiring = true;
            ShootFromAmmo();
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Invoke("SetFiring", fireTime);
            ShootSounds();
        }
        else
        {
            ammoClick.Play();
        }     
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }

        if (HasAmmo())
        {
            OutOfAmmo = true;
        }

        if (Input.GetKeyDown("r") && OutOfAmmo == true)
        {
            OutOfAmmo = false;
            ReloadWeapon();

        }
    }

    private void OnGUI()
    {
        if (OutOfAmmo == true)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.font = (Font)Resources.Load("Bebas");
            style.fontSize = 35;
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, Screen.height - 50,200,30), "Press [R] to reload Weapon", style);
        }
    }

    void ShootSounds()
    {
        if (GameUI.WeaponIndex == 1 || GameUI.WeaponIndex == 3 || GameUI.WeaponIndex == 5)
        {
            gunShot.Play();
        }
        else if (GameUI.WeaponIndex == 2)
        {
            shotgunFire.Play();
        }
        else if (GameUI.WeaponIndex == 4)
        {
            rocketFire.Play();
        }
    }

    void ReloadWeapon()
    {
        if (GameUI.WeaponIndex == 1)
        {
            magReload.Play();
            //Pistol
            if (GameUI.Pistol.RemainingAmmo < 12)
            {
                GameUI.Pistol.CurrentMag += GameUI.Pistol.RemainingAmmo;
                GameUI.Pistol.RemainingAmmo = 0;
            }
            else
            {
                GameUI.Pistol.RemainingAmmo -= 12;
                GameUI.Pistol.CurrentMag = 12;
            }
        }
        if (GameUI.WeaponIndex == 2)
        {
            shotgunReload.Play();
            //Shotgun
            if (GameUI.Shotgun.RemainingAmmo < 2)
            {
                GameUI.Shotgun.CurrentMag += GameUI.Shotgun.RemainingAmmo;
                GameUI.Shotgun.RemainingAmmo = 0;
            }
            else
            {
                GameUI.Shotgun.RemainingAmmo -= 2;
                GameUI.Shotgun.CurrentMag = 2;
            }
        }
        if (GameUI.WeaponIndex == 3)
        {
            magReload.Play();
            //Automatic
            if (GameUI.Automatic.RemainingAmmo < 32)
            {
                GameUI.Automatic.CurrentMag += GameUI.Automatic.RemainingAmmo;
                GameUI.Automatic.RemainingAmmo = 0;
            }
            else
            {
                GameUI.Automatic.RemainingAmmo -= 32;
                GameUI.Automatic.CurrentMag = 32;
            }
        }
        if (GameUI.WeaponIndex == 4)
        {
            rocketReload.Play();
            //Rocket
            if (GameUI.Rocket.RemainingAmmo < 1)
            {
                GameUI.Rocket.CurrentMag += GameUI.Rocket.RemainingAmmo;
                GameUI.Rocket.RemainingAmmo = 0;
            }
            else
            {
                GameUI.Rocket.RemainingAmmo -= 1;
                GameUI.Rocket.CurrentMag = 1;
            }
        }
        if (GameUI.WeaponIndex == 5)
        {
            magReload.Play();
            //Rifle
            if (GameUI.Rifle.RemainingAmmo < 20)
            {
                GameUI.Rifle.CurrentMag += GameUI.Rifle.RemainingAmmo;
                GameUI.Rifle.RemainingAmmo = 0;
            }
            else
            {
                GameUI.Rifle.RemainingAmmo -= 20;
                GameUI.Rifle.CurrentMag = 20;
            }
        }
    }

    void ShootFromAmmo()
    {
        if (GameUI.WeaponIndex == 1)
        {
            //Pistol
            GameUI.Pistol.CurrentMag -= 1;
        }
        if (GameUI.WeaponIndex == 2)
        {
            //Shotgun
            GameUI.Shotgun.CurrentMag -= 1;
        }
        if (GameUI.WeaponIndex == 3)
        {
            //Automatic
            GameUI.Automatic.CurrentMag -= 1;
        }
        if (GameUI.WeaponIndex == 4)
        {
            //Rocket
            GameUI.Rocket.CurrentMag -= 1;
        }
        if (GameUI.WeaponIndex == 5)
        {
            //Rifle
            GameUI.Rifle.CurrentMag -= 1;
        }
    }

    private bool HasAmmo()
    {
        if (GameUI.WeaponIndex == 1)
        {
            //Pistol
            if (GameUI.Pistol.CurrentMag == 0)
            {
                return true;
            }
        }
        if (GameUI.WeaponIndex == 2)
        {
            //Shotgun
            if (GameUI.Shotgun.CurrentMag == 0)
            {
                return true;
            }
        }
        if (GameUI.WeaponIndex == 3)
        {
            //Automatic
            if (GameUI.Automatic.CurrentMag == 0)
            {
                return true;
            }
        }
        if (GameUI.WeaponIndex == 4)
        {
            //Rocket
            if (GameUI.Rocket.CurrentMag == 0)
            {
                return true;
            }
        }
        if (GameUI.WeaponIndex == 5)
        {
            //Rifle
            if (GameUI.Rifle.CurrentMag == 0)
            {
                return true;
            }
        }

        return false;

    }
}
