using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonGenerator : MonoBehaviour
{
    [SerializeField] List<EnemyWeights> enemyPrefabs = new List<EnemyWeights>();
    [SerializeField]
    Collider baseCollider;
    //GameObject[] ballonPrefabs;
    
    [SerializeField] List<EnemyPriority> enemyPriorities = new List<EnemyPriority>();

    [SerializeField] float creationCooldown=2f;
    float currentCooldown=0;
    int ballonQuant = 5;

    void Start()
    {
        // i want the game to spawn inmediatly
        currentCooldown = creationCooldown;
    }


    void Update()
    {
        
        if(currentCooldown>=creationCooldown)
        {
            GenerateBallons(EnemySelectorByWeight(enemyPrefabs));
            currentCooldown=0;
        }
        else
        {
            currentCooldown+=1f* Time.deltaTime;
        }
 
    }

    private GameObject EnemySelectorByWeight(List<EnemyWeights> enemyWeightsList)
    {
        var rand=Random.Range(0f,1f);

        foreach(EnemyWeights weight in enemyWeightsList)
        {
            if(weight.priority == MatchProb(rand))
            {
                //print("random number was: "+rand);
                //print("name of prefab selected is: "+ weight.name);
                return weight.enemyPrefab;
            }
        }
        return null;
    }

    private int MatchProb(float rand)
    {
        foreach(EnemyPriority p in enemyPriorities)
        {
            if(p.probMin < rand  &&  rand <=p.probMax)
            {
                return p.priority;
            }
        }
        return -1;
    }

    public void ReassingPriorities()
    {
    
    }


    public static Vector3 RandomPointInBounds(Bounds bounds) {
    return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
    );}


    public void GenerateBallons(GameObject prefabToSpawn)
    {
        var ballon =Instantiate(prefabToSpawn, RandomPointInBounds(baseCollider.bounds), Quaternion.identity);
        ballon.transform.localScale=new Vector3(0.01f,0.01f,0.01f);

    }
}
