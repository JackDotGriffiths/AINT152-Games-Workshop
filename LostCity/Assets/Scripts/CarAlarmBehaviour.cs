using UnityEngine;
using System.Collections;

public class CarAlarmBehaviour : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip CarAlarm;

    void OnTrigger2D(Trigger2D other)
    {
        if (other.gameObject.tag == "Bullet(Clone)")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = CarAlarm;
            audioSource.Play();
        }
    }
}