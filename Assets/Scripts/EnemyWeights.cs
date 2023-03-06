using System.Globalization;
using UnityEngine;


[System.Serializable]
struct EnemyWeights {
    //Variable declaration
    //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
    public int minProb;
    public int maxProb;
    public GameObject enemyPrefab;
    //Constructor (not necessary, but helpful)
    public EnemyWeights(int minProb, int maxProb, GameObject enemyPrefab) {
        this.minProb = minProb;
        this.maxProb = maxProb;
        this.enemyPrefab = enemyPrefab;
    }
}