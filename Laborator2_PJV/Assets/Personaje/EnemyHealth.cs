using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 3;
    public GenerateEnemies gameEnemies, enemy;
    public EnemyController enemyController;
    public PlayerController playerScore;
   
    // Update is called once per frame
    void Awake()
    {
        gameEnemies = FindObjectOfType<GenerateEnemies>();
        enemy = FindObjectOfType<GenerateEnemies>();
        playerScore = FindObjectOfType<PlayerController>();
        enemyController = GetComponent<EnemyController>();
    }

    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth == 0)
        {
            //Destroy(gameObject);
            MakeDied();
            gameEnemies.enemyCount -= 1;
            playerScore.noDeadEnemies += 1;
            Debug.Log("Ai doborat " + playerScore.noDeadEnemies + " inamici.");
        }
    }

    public void MakeDied()
    {
        enemyController.Death();
        Destroy(gameObject, 2.5f);
    }
}
