using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerDamage : MonoBehaviour
{
    public float health = 100;
    public float enemyDamage = 4;
    public float wallDamage = 5;
    public Text textbox;

    SpriteRenderer image; //Set sprites
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.transform.Find("body").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Health:" + health;
        if (health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            image.sprite = sprite5;

        } 
        else if (health <=25)
        {
            image.sprite = sprite4;
        }
        else if (health <= 50)
        {
            image.sprite = sprite3;
        }
        else if (health <= 75)
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
        if (col.gameObject.tag =="Enemy") {
            health -= enemyDamage;

        }
        else if(col.gameObject.tag == "Wall")
        {
            health -= wallDamage;
        }

    }
}
