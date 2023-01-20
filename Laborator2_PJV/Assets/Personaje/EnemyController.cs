using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody theRb;
    EnemyHealth currentHp;
    private Animator enemyAnimator;

    void Awake()
    {
       currentHp = FindObjectOfType<EnemyHealth>();
       enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(PlayerController.instance.transform.position);
        theRb.velocity = transform.forward * moveSpeed;

        if (currentHp.currentHealth <= 0)
        {
            theRb.velocity = Vector3.zero;
        }
    }

    public void Death()
    {
        moveSpeed = 0.0f;
        enemyAnimator.SetTrigger("Death");
    }
}
