using System.Collections.Generic;
using UnityEngine;


public class SceneEnemyTracking : MonoBehaviour
{
     List<string> enemies = new List<string>();
     int normal;
     int faster;
     int slow;
    public void TrackEnemyType(string nameOfEnemy)
    {
        enemies.Add(nameOfEnemy);
    }


}