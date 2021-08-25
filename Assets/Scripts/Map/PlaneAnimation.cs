using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAnimation : MonoBehaviour
{


    public float speed;


    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0,1,0), 0.1f * speed);    
    }
}
