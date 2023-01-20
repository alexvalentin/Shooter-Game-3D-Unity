using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    private float score, lastTimeShot = 0;
   
    public int noDeadEnemies = 0;

    public Image image;
    public Image image2;

    [SerializeField] float firingSpeed;

    public static PlayerController instance;
    public GenerateEnemies gameEnemy;
    

    private void Awake()
    {
        instance = this;
        gameEnemy = FindObjectOfType<GenerateEnemies>();
        image = GetComponent<Image>();
        image2 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShootInput();
    }


    void HandleShootInput()

        {   
            if (Input.GetButton("Fire1"))
            {
                if (lastTimeShot + firingSpeed <= Time.time)
                {
                    lastTimeShot = Time.time;
                    Debug.Log("Am apasat click stanga!");
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }  
            }

            if (Input.GetButton("Fire2"))
            {
                if (lastTimeShot + firingSpeed <= Time.time)
                {

                    lastTimeShot = Time.time;
                    Debug.Log("Am apasat click dreapta!");
              
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "enemy")
                        {
                            Destroy(hit.transform.gameObject);
                            gameEnemy.enemyCount -= 1;
                            noDeadEnemies += 1;
                            Debug.Log("Ai doborat " + noDeadEnemies + " inamici.");
                        }
                    }
                }
            }

        }
}
