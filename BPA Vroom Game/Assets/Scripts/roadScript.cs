using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D col){ 
        if (col.tag == "Wheel") {
            col.gameObject.GetComponent<TrailRenderer>().emitting = false;
            col.gameObject.GetComponent<tireSound>().onRoad = true;


        }
        if (col.tag == "Player") {
           col.gameObject.GetComponent<carController>().maxSpeed = 75f;
        }

    }
    void OnTriggerExit2D (Collider2D col) {
        if (col.tag == "Wheel") {
            col.gameObject.GetComponent<TrailRenderer>().emitting = true;
            col.gameObject.GetComponent<tireSound>().onRoad = false;

        }
        if (col.tag == "Player") {
           col.gameObject.GetComponent<carController>().maxSpeed = 65f;
        }

    }
}
