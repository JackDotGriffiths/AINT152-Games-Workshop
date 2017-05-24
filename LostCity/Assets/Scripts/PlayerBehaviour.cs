using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int health = 100;

    private Animator gunAnim;
    private Sprite newSprite;

    public Sprite Playerrifle;
    public Sprite Playershotgun;
    public Sprite Playerautomatic;
    public Sprite Playerrocket;
    public Sprite Playerpistol;

    void Start()
    {
        gunAnim = GetComponent<Animator>();
        SendHealthData();
    }
    void Update()
    {
        if (GameUI.WeaponIndex == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Playerpistol;
        }
        else if (GameUI.WeaponIndex == 2)
        {
            GetComponent<SpriteRenderer>().sprite = Playershotgun;
        }
        else if (GameUI.WeaponIndex == 3)
        {
            GetComponent<SpriteRenderer>().sprite = Playerautomatic;
        }
        else if (GameUI.WeaponIndex == 4)
        {
            GetComponent<SpriteRenderer>().sprite = Playerrocket;
        }
        else if (GameUI.WeaponIndex == 5)
        {
            GetComponent<SpriteRenderer>().sprite = Playerrifle;
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
}
