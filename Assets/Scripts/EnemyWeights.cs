using System.Globalization;
using UnityEngine;


[System.Serializable]
struct EnemyWeights {
    //Variable declaration
    //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
    public float minProb;
    public float maxProb;

    public string name;
    public GameObject enemyPrefab;
    //Constructor (not necessary, but helpful)
    public EnemyWeights(string name, float minProb, float maxProb, GameObject enemyPrefab) {
        this.minProb = minProb;
        this.maxProb = maxProb;
        this.enemyPrefab = enemyPrefab;
        this.name = name;
        Debug.Log(name.ToString());
    }
}