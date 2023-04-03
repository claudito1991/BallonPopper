
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    [SerializeField] int maxHealth=100;
    [SerializeField] int currentHealth;
    [SerializeField] HealthManager health;
    [SerializeField] int amountOfDamage=1;

    [SerializeField] private ResetGame resetGame;


    
    void Start()
    {

        health.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    
    }
    void OnEnable()
    {
        BallonDetection.ballonAttack += TakeDamage;
        resetGame.ResetTheGame += ResetState;
    }

    private void ResetState()
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
            GetComponent<GameOver>().GameIsOver();
        }
    }


    void OnDisable()
    {
        BallonDetection.ballonAttack -= TakeDamage;
        resetGame.ResetTheGame -= ResetState;
    }

}
