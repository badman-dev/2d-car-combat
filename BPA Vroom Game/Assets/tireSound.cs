using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tireSound : MonoBehaviour
{
    public AudioSource screech;
    public bool onRoad;

    Vector3 lastPosition = Vector3.zero;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        onRoad = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(speed);
        if (onRoad && Input.GetKey(KeyCode.Space) && (speed > .01 || Input.GetKey(KeyCode.W))) {
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
    
    void FixedUpdate()
    {
        speed = (transform.parent.gameObject.transform.position - lastPosition).magnitude;
        lastPosition = transform.parent.gameObject.transform.position;
    }
}
