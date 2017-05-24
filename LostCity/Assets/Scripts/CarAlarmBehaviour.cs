using UnityEngine;
using System.Collections;

public class CarAlarmBehaviour : MonoBehaviour
{
    public string Tag = "";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}