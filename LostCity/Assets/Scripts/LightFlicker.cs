using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    // Update is called once per frame
    public Light MyLight;
    void Update()
    {
        if (Random.value > 0.9) //a random chance
        {
            if (MyLight.enabled == true) //if the light is on...
            {
                MyLight.enabled = false; //turn it off
            }
            else
            {
                MyLight.enabled = true; //turn it on
            }
        }
    }
}
