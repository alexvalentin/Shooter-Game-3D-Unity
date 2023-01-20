using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public int spritePerFrame = 6;
    public bool loop = true;
    public bool destroyOnEnd = false;

    private int index = 0;
    private Image image;
    private Image image2;
   
    private int frame = 0;

    public PlayerController player;

    void Awake()
    {
        image = GetComponent<Image>();
        image2 = GetComponent<Image>();

        player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        image.enabled = false;
        image2.enabled = false;
       
    }

    void Update()
    {
        if (player.noDeadEnemies % 5 == 0 && player.noDeadEnemies !=0)
        {

            image.enabled = true;

            if (!loop && index == sprites.Length) return;
            frame++;
            if (frame < spritePerFrame) return;
            image.sprite = sprites[index];
            frame = 0;
            index++;
            if (index >= sprites.Length)
            {
                if (loop) index = 0;
                if (destroyOnEnd) StartCoroutine(DestroyAnimatedImage());
              
            }

            //image.enabled = false;
        }

       
    }

    IEnumerator DestroyAnimatedImage()
    {
        yield return new WaitForSeconds(4); 
        Destroy(gameObject); 
    }
}