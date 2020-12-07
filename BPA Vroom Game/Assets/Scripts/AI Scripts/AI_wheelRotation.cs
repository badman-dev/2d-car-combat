using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_wheelRotation : MonoBehaviour
{
    float maxRot = 40f;
    float minRot = -40f;
    float defRot = 0f;
    float rotateSpeed = 5f;
    float lTimer = 0;
    float rTimer = 0;
    GameObject body;
    public TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        body = this.transform.parent.gameObject;
        tr.sortingLayerName = "Player";
        tr.sortingOrder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        defRot = body.transform.rotation.eulerAngles.z;
        maxRot = defRot + 40;
        minRot = defRot - 40;

    }
}
