using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public GameObject objectPrefab;
    public void Spawn()
    {
        if (RoundControl.ZombiesSpawned != RoundControl.ZombiesAmountToSpawn){
            RoundControl.ZombiesSpawned += 1;
            Instantiate(objectPrefab, transform.position, transform.rotation);
        }
        else
        {
            return;
        }
    }
}
