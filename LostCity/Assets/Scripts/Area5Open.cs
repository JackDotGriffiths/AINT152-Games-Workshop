using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area5Open : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<SpawnObjectTimer>().enabled = false;
        GetComponent<SpawnObject>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BuyDoor.Area5Open == true)
        {
            GetComponent<SpawnObjectTimer>().enabled = true;
            GetComponent<SpawnObject>().enabled = true;
        }
    }
}
