using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision Bullet)
    {
            audio.Play();
    }
}