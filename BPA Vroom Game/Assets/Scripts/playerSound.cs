using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour
{
    public AudioSource engine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");

        if (v >= 0) {
            engine.pitch = v + 1;
        }
        else {
            engine.pitch = -(v) + 1;
        }

        

        
    }
}
