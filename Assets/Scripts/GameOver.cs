using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameOver : MonoBehaviour
{
    private bool gameIsOver= false;
    GameObject[] enemies;
    void Awake()
    {
        this.enabled = false;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        print("Game Over");
        gameIsOver  = true;
        //Time.timeScale = 0;
    }

    void Update()
    {
        if(gameIsOver)
        {
            DisableBalloons();
            DisableWave();
        }
    }
    private void DisableBalloons()
    {
            enemies = GameObject.FindGameObjectsWithTag("enemy");

            foreach(GameObject balloon in enemies)
            {
            
                Destroy(balloon.GetComponent<BallonControler>());
                Destroy(balloon.GetComponent<BallonMovement>());
            }
    }
    
        
    private void DisableWave()

    {
        FindObjectOfType<EventsManager>().EnemyWaveOff();
    }
}