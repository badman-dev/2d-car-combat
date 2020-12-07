using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tireSound : MonoBehaviour
{
    public AudioSource screech;
    public bool onRoad;
    // Start is called before the first frame update
    void Start()
    {
        onRoad = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onRoad && Input.GetKey(KeyCode.Space)) {
            if (!screech.isPlaying) {
                screech.Play();
                gameObject.transform.GetChild(0).gameObject.GetComponent<TrailRenderer>().emitting = true;
            }
            
        }
        else {
            screech.Stop();
            gameObject.transform.GetChild(0).gameObject.GetComponent<TrailRenderer>().emitting = false;
        }
        
    }
}
