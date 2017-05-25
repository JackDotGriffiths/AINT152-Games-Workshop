using UnityEngine;
using System.Collections;

public class BuyDoor : MonoBehaviour
{
    public string Tag = "";
    public int cost;
    public bool triggered;
    public GameObject destory;
    public static bool Area2Open = false;
    public static bool Area3Open = false;
    public static bool Area4Open = false;
    public static bool Area5Open = false;

    void OnGUI()
    {
        if (triggered == true)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.font = (Font)Resources.Load("Bebas");
            style.fontSize = 35;
            
            GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "Press [F] to clear debris for " + cost, style);
        }
    }
    private void Update()
    {
        bool afford = false;
        if (GameObject.Find("UserInterface").GetComponent<GameUI>().score >= cost)
        {
            afford = true;
        }
        if (Input.GetKeyDown("f") && triggered == true && afford == true)
        {
            allowSpawning();
            GameObject.Find("UserInterface").GetComponent<GameUI>().score -= cost;
            Destroy(gameObject);
            Destroy(destory);
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

    private void allowSpawning()
    {
        if (destory == GameObject.Find("Road_Barrier 1"))
        {
            Area2Open = true;
            AreaSpawnerControl.Spawner3Active = true;
            AreaSpawnerControl.Spawner4Active = true;
            AreaSpawnerControl.Spawner5Active = true;
        }
        if (destory == GameObject.Find("Road_Barrier 2"))
        {
            Area4Open = true;
            AreaSpawnerControl.Spawner8Active = true;
            AreaSpawnerControl.Spawner9Active = true;

        }
        if (destory == GameObject.Find("Road_Barrier 3"))
        {
            Area3Open = true;
            AreaSpawnerControl.Spawner6Active = true;
            AreaSpawnerControl.Spawner7Active = true;
        }
        if (destory == GameObject.Find("Road_Barrier 4"))
        {
            Area3Open = true;
            Area4Open = true;
            AreaSpawnerControl.Spawner8Active = true;
            AreaSpawnerControl.Spawner9Active = true;
            AreaSpawnerControl.Spawner6Active = true;
            AreaSpawnerControl.Spawner7Active = true;

        }
        if (destory == GameObject.Find("Road_Barrier 5"))
        {
            Area5Open = true;
            AreaSpawnerControl.Spawner10Active = true;
            AreaSpawnerControl.Spawner11Active = true;
            AreaSpawnerControl.Spawner12Active = true;
        }
    }
}