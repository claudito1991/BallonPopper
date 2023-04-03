using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameOver : MonoBehaviour
{
    [SerializeField] private bool gameIsOver= false;
    
    [SerializeField] GameObject resetButton;
    GameObject[] enemies;

    private SpawnEnemyFromStage spawnEnemyFromStage;

    void Start()
    {
        spawnEnemyFromStage = GetComponent<SpawnEnemyFromStage>();
    }
    public void GameIsOver()
    {
        resetButton.SetActive(true);
        DisableBalloons();
        spawnEnemyFromStage.canSpawn = false;
        //DisableWave();

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
        //FindObjectOfType<EventsManager>().EnemyWaveOff();
    }
}