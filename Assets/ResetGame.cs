using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public Action ResetTheGame;
    private SpawnEnemyFromStage spawnEnemyFromStage;

    [SerializeField] GameObject resetButton;
    

    void Start()
    {
        spawnEnemyFromStage = FindObjectOfType<SpawnEnemyFromStage>();
    }
    // Start is called before the first frame update

    public void ResetGameState()
    {
        Debug.Log("Reseted");
        ResetTheGame?.Invoke();
        resetButton.SetActive(false);
        spawnEnemyFromStage.canSpawn = true;
    }

}
