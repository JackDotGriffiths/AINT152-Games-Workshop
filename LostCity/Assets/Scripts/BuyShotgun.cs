using UnityEngine;
using System.Collections;

public class BuyShotgun : MonoBehaviour
{
    public string Tag = "";
    public int Ammocost = 1000;
    public int cost = 1500;
    public bool triggered;
    public bool Purchased = false;
    public bool needAmmo = false;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.font = (Font)Resources.Load("Bebas");
        style.fontSize = 35;
        if (needAmmo = true && Purchased == true && triggered == true)
        {
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "Press [F] to buy Shotgun ammo for " + Ammocost, style);
        }
        if (triggered == true && Purchased == false)
        {
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "Press [F] to buy Shotgun for " + cost, style);
        }
    }
    private void Update()
    {
        bool affordGun = false;
        bool affordAmmo = false;
        if (GameUI.Shotgun.RemainingAmmo < 200)
        {
            needAmmo = true;
        }
        if (GameObject.Find("UserInterface").GetComponent<GameUI>().score >= cost)
        {
            affordGun = true;
        }
        if (GameObject.Find("UserInterface").GetComponent<GameUI>().score >= Ammocost)
        {
            affordAmmo = true;
        }
        if (Input.GetKeyDown("f") && triggered == true && affordGun == true && Purchased == false)
        {
            GameUI.Shotgun.Unlocked = true;
            GameUI.WeaponIndex = 2;
            GameObject.Find("UserInterface").GetComponent<GameUI>().score -= cost;
            Purchased = true;
            affordGun = false;
            return;
        }
        if (Input.GetKeyDown("f") && triggered == true && affordAmmo == true && Purchased == true && needAmmo == true)
        {
            GameUI.Shotgun.RemainingAmmo = 200;
            GameObject.Find("UserInterface").GetComponent<GameUI>().score -= cost;
            affordAmmo = false;
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
}