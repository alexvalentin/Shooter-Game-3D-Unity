using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody rb;
    float score;

    public int damage = 1;

    void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Destroy(collision.gameObject);
            transform.parent = collision.transform;
            collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(damage);
        }
        Destroy(gameObject);
    }

}

