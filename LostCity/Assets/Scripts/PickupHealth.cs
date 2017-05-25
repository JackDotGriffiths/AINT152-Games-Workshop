using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public string Tag = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            if (GameUI.health != 100)
            {
                GameUI.health = 100;
                Destroy(gameObject);
            }
        }

    }
}