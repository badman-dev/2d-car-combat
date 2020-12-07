using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelTurn : MonoBehaviour
{
        float maxRot = 40f;
        float minRot = -40f;
        float defRot = 0f;
        float rotateSpeed = 5f;
        float lTimer = 0;
        float rTimer = 0 ;
        GameObject body;
        public TrailRenderer tr;

        
    
    // Start is called before the first frame update
    void Start()
    {
       body = this.transform.parent.gameObject;
       tr.sortingLayerName = "Player";
       tr.sortingOrder = 0;
       
    }

    void Update()
    {
        defRot = body.transform.rotation.eulerAngles.z;
        
        maxRot = defRot + 40;  
        minRot = defRot - 40;
        

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) {
           if (gameObject.transform.rotation.z != 0) {
               gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, defRot), rotateSpeed * Time.deltaTime);
               

           }
       }
       if (Input.GetKey(KeyCode.A) && lTimer <= rTimer) {
           //if (gameObject.transform.rotation.z < maxRot) {
               gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, maxRot), rotateSpeed * Time.deltaTime);
          // }
          lTimer += Time.deltaTime;
       }
       else {
           lTimer = 0;
       }
       if (Input.GetKey(KeyCode.D) && rTimer <= lTimer) {
           //if (gameObject.transform.rotation.z > minRot) {
               gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, minRot), rotateSpeed * Time.deltaTime);
          // }
          rTimer += Time.deltaTime;
       }
       else {
           rTimer = 0;
       }
       
    }
    

    
}
