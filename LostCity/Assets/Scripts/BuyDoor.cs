using UnityEngine;
using System.Collections;

public class BuyDoor : MonoBehaviour
{
    public string Tag = "";
    public int cost;
    public bool triggered;
    public GameObject destory;
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
}