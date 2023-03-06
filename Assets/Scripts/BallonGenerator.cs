using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonGenerator : MonoBehaviour
{
    [SerializeField] EnemyWeights[] enemyPrefabs;
    [SerializeField]
    Collider baseCollider;
    [SerializeField]
    GameObject[] ballonPrefabs;
  
    float creationCooldown=2f;
    float currentCooldown=0;
    int ballonQuant = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    private GameObject EnemySelectorByWeight(EnemyWeights[] enemyWeightsList)
    {
        var rand=Random.Range(0f,1f);

        foreach(EnemyWeights weight in enemyWeightsList)
        {
            if(rand >=weight.minProb && rand < weight.maxProb)
            {
                FindObjectOfType<SceneEnemyTracking>().TrackEnemyType(weight.name);
                //print($"{rand} and {weight.enemyPrefab.ToString()}");
                return weight.enemyPrefab;
                
            }
        }

        //print($"OUT FOREACH and {enemyWeightsList[0].ToString()}");
        FindObjectOfType<SceneEnemyTracking>().TrackEnemyType(enemyWeightsList[0].name);
        return enemyWeightsList[0].enemyPrefab;
        

    }

    private int EnemyRandomInt()
    {
        return Random.Range(0, ballonPrefabs.Length);
    }
    
    private GameObject EnemySelector(int enemyPosition)
    {
        return ballonPrefabs[EnemyRandomInt()];
    }
    public static Vector3 RandomPointInBounds(Bounds bounds) {
    return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
    );}


    public void GenerateBallons(GameObject prefabToSpawn)
    {
        var ballon =Instantiate(EnemySelector(0), RandomPointInBounds(baseCollider.bounds), Quaternion.identity);
        ballon.transform.localScale=new Vector3(0.01f,0.01f,0.01f);

    }
}
