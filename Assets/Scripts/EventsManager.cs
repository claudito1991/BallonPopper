using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    [SerializeField]
    int maxHealth=100;
    [SerializeField]
    int currentHealth;
    [SerializeField]

    HealthManager health;
    [SerializeField]
    int amountOfDamage=1;
    void OnEnable()
    {
        BallonDetection.ballonAttack += TakeDamage;
    }

    void Start()
    {
        health.SetMaxHealth(maxHealth);
        currentHealth = maxHealth; 

    }
    public void TakeDamage()
    {
        currentHealth -= amountOfDamage;
        health.SetHealth(currentHealth);
        if(currentHealth <=0)
        {
            GetComponent<GameOver>().enabled = true;
        }
    }

    public void EnemyWaveOn()
    {
        FindObjectOfType<BallonGenerator>().canSpawn = true;
    }


    public void EnemyWaveOff()
    {
        FindObjectOfType<BallonGenerator>().canSpawn = false;
    }

    void OnDisable()
    {
        BallonDetection.ballonAttack -= TakeDamage;
    }

}
