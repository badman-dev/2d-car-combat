using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float health = 40;
    public float playerDamage = 4;
    public float wallDamage = 5;
    public float projDamage = 15;


    SpriteRenderer image; //Set sprites
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    void Start()
    {
        image = gameObject.transform.Find("body").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Manages changing of sprites/disabling based on health
        if (health <= 0)
        {

            this.GetComponent<AI_playerLocater>().detectionRadius = 0; //Disables enemy
        }
        else if (health <= 10)
        {
            image.sprite = sprite4;
        }
        else if (health <= 20)
        {
            image.sprite = sprite3;
        }
        else if (health <= 30)
        {
            image.sprite = sprite2;
        }
        else
        {
            image.sprite = sprite1;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            health -= playerDamage;

        }
        else if (col.gameObject.tag == "Wall")
        {
            health -= wallDamage;
        }
        else if (col.gameObject.name == "bullet")
        {
            health -= projDamage;
        }

    }
}
