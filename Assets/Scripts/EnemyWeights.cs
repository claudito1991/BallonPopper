using System.Globalization;
using UnityEngine;


[System.Serializable]
struct EnemyWeights {
    //Variable declaration
    //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
    //public float minProb;
    //public float maxProb;
    public int priority;
    public string name;
    public GameObject enemyPrefab;
    //Constructor (not necessary, but helpful)
    public EnemyWeights(string name, int priority, GameObject enemyPrefab) {
        this.priority = priority;
        this.enemyPrefab = enemyPrefab;
        this.name = name;
     
    }
}