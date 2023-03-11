using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallonDetection : MonoBehaviour
{
    public static Action ballonAttack;
    // Start is called before the first frame update
void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("enemy"))
    {
        //Debug.Log("Enemy in target!");
        //Destroy(other.gameObject);
        ballonAttack?.Invoke();
    }

}

void Update()
{
    //balloon detection in scene 

   //var ballonsInScene = FindObjectsOfType<BallonControler>().Length;
    //print(ballonsInScene);
}
}
