using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonAnimation : MonoBehaviour
{
    
    public PlayerController playerControl;
    public Animator animatieDragon;

    public Image image;

    // Start is called before the first frame update
    void Awake()
    {
        animatieDragon = GetComponent<Animator>();
        playerControl = FindObjectOfType<PlayerController>();
        image = GetComponent<Image>();
    }
    void Start()
    {
       // animatieDragon.enabled = false;
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.noDeadEnemies == 10)
        {
            image.enabled = true;
            //animatieDragon.enabled = true;
            //animatieDragon.Play("animDragoon");

        }
        
    }
}
