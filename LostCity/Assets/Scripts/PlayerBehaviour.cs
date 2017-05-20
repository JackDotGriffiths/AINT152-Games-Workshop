using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int health = 100;
    public int WeaponIndex;
    private Animator gunAnim;
    private Sprite newSprite;

    void Start()
    {
        gunAnim = GetComponent<Animator>();
        SendHealthData();
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            WeaponIndex += 1;
            if (WeaponIndex == 6)
            {
                WeaponIndex = 1;
            }
            WeaponChangeBehaviour();
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            WeaponIndex -= 1;
            if (WeaponIndex == 0)
            {
                WeaponIndex = 6;
            }
            WeaponChangeBehaviour();

        }
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("isFiring", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
    }
    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
    public void WeaponChangeBehaviour()
    {

        if (WeaponIndex== 1)
        {

        }
        if (WeaponIndex == 2)
        {

        }
        if (WeaponIndex == 3)
        {

        }
        if (WeaponIndex == 4)
        {

        }
        if (WeaponIndex == 5)
        {

        }
        if (WeaponIndex == 6)
        {

        }
    }
}
