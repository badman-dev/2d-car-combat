using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyAccelerate : MonoBehaviour
{
    private Rigidbody2D rb2d;
    float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float h = -Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W)) {
            if (speed < 1) {
            speed += .1f*Time.deltaTime;
        } 

        } else {
            speed-=1f*Time.deltaTime;
        }
        if (speed < 0) {
            speed = 0;
        }
        

    }
    void FixedUpdate()
    {
        
        rb2d.AddRelativeForce(transform.up*speed,ForceMode2D.Impulse);

        
    }
}
