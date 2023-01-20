using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos, zPos;
    public int enemyCount = 0;
    public int maxEnemiesOnScene = 5;
  
    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        if (enemyCount < maxEnemiesOnScene)
        {
            xPos = Random.Range(30, 40);
            zPos = Random.Range(31, 41);

            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            enemyCount += 1;
            yield return new WaitForSeconds(2.0f);
        }
        
    } 
}
