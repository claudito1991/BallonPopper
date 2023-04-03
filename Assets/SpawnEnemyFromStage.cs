using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnEnemyFromStage : MonoBehaviour
{
    [SerializeField] List<SpawnState> spawnStages;
    [SerializeField] BoxCollider spawnBaseCollider; 
    [SerializeField] float globalTime; 

    [SerializeField] float spawnCooldown;
    [SerializeField] float currentCooldown;

    [SerializeField] int currentStageIndex;
    
    [SerializeField] SpawnState currentStage;
    
    [SerializeField] bool timerReset;  // Start is called before the first frame update
    [SerializeField] private bool coolDownTimerFinish;
    public bool canSpawn;
    [SerializeField] ResetGame resetGame;

    void Start()
    {
        InitialState();

    }


    void OnEnable()
   {
    resetGame.ResetTheGame += ResetSpawnState;
   }



    // Update is called once per frame
    void Update()
    {
        if(!canSpawn) return;
    
        if(timerReset)
        {
            SwitchingStages();
        }

        if(coolDownTimerFinish)
        {
            SpawningEnemy(currentStage);
        }

        // currentCooldown += Time.deltaTime;
        // if(currentCooldown>= spawnCooldown)
        // {
        //     currentCooldown = 0f;
        //     SpawningEnemy(currentStage);
        // }
    }

    private void SwitchingStages()
    {
        // Timer is reseted and stage index advance 1 int. Timer start to count again
        Debug.Log("stage change");
        timerReset = false;
        if (currentStageIndex != spawnStages.Count - 1)
        {
            currentStageIndex++;
        }

        currentStage = spawnStages[currentStageIndex];
        StartCoroutine(StageTimer(currentStage.stageDuration));
    }

    void SpawningEnemy(SpawnState stage)
    {   
        // spawn cooldown is reseted, timer starts to count again and enemy is spawned based on current stage
        coolDownTimerFinish = false;
        StartCoroutine(SpawnCooldown(spawnCooldown));
        var stages = stage.spawnObjects;
        var stagesProb = stage.spawnProbability;

        float probabilitySum = 0f;
        float randomNum = Random.Range(0f, 1f);

        for(int i = 0; i<stages.Count; i++)
        {
            //if(probabilitySum >= 1f) probabilitySum=0f;
            probabilitySum += stagesProb[i];

            //Debug.Log("probability sum:" + probabilitySum);
            //Debug.Log("Rnd: " + randomNum);
            if(randomNum <= probabilitySum)
            {
                GenerateBallons(stages[i]);
                break;
            }
        }
    }

    void OnDisable()
    {
        resetGame.ResetTheGame -= ResetSpawnState;
    }

    private void ResetSpawnState()
    {
        InitialState();
    }

        private void InitialState()
    {
        canSpawn = true;
        currentStageIndex = 0;
        currentStage = spawnStages[currentStageIndex];
        StartCoroutine(StageTimer(currentStage.stageDuration));
        currentCooldown = 0f;
        timerReset = false;
        coolDownTimerFinish = true;
    }


    private IEnumerator StageTimer(float waitTime)
    {
        
        float counter = 0f;

        while (counter < waitTime)
        {
            //Debug.Log("Current WaitTime: " + counter);
            counter += Time.deltaTime;
            yield return null; //Don't freeze Unity
        }
        timerReset = true;
        

    }

    private IEnumerator SpawnCooldown(float waitTime)
    {
        
        float counter = 0f;
        while (counter < waitTime)
        {
            //Debug.Log("Current WaitTime: " + counter);
            counter += Time.deltaTime;
            yield return null; //Don't freeze Unity
        }
        coolDownTimerFinish = true;
        

    }



    public static Vector3 RandomPointInBounds(Bounds bounds) {
    return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
    );}


    public void GenerateBallons(GameObject prefabToSpawn)
    {
        var ballon =Instantiate(prefabToSpawn, RandomPointInBounds(spawnBaseCollider.bounds), Quaternion.identity);
        ballon.transform.localScale=new Vector3(0.01f,0.01f,0.01f);

    }
}
