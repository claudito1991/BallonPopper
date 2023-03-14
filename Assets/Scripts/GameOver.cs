using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameOver : MonoBehaviour
{
    private bool gameIsOver= false;
    void Awake()
    {
        this.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        print("Game Over");
        gameIsOver  = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if(gameIsOver)
        {
            DisableBalloons();
        }
    }
    private void DisableBalloons()
    {
        foreach(BallonControler balloon in FindObjectsOfType<BallonControler>())
        {
            if(balloon.enabled)
            {
                balloon.enabled = false;
            }

        }
    }


}
