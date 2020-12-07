using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePoint : MonoBehaviour
{
    // Start is called before the first frame update
    private float angle;
    private Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
