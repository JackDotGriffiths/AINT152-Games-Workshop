using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDoor1 : MonoBehaviour {

    bool hasCollided = false;
    string labelText = "";
 
    void OnGUI()
    {
        if (hasCollided == true)
        {
            GUI.Box(new Rect(140, Screen.height - 50, Screen.width - 300, 120), (labelText));
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")

        {

            hasCollided = true;
            labelText = "Hit F to move the barrier!";

        }
    }

    void OnTriggerExit(Collider other )
    {
        hasCollided = false;

    }

}
