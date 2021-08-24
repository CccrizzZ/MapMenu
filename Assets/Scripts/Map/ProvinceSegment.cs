using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceSegment : MonoBehaviour
{

    public GameObject border;

    public MapController MController;





    void Start()
    {
        // MController = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();
    }



    void OnMouseEnter() 
    {

        // GetComponent<Renderer>().material = MController.HighlightCore;
        // border.GetComponent<Renderer>().material = MController.HighlightBorder;
    }

    void OnMouseExit() 
    {
        // GetComponent<Renderer>().material = MController.NormalCore;
        // border.GetComponent<Renderer>().material = MController.NormalBorder;
    }


    void OnMouseDown() 
    {
        // if (!Input.GetKey(KeyCode.LeftShift)) return;
        // look at the clicked province
        // Camera.main.transform.LookAt(border.transform);



        // pass it to map controller
        // MController.StartMovingCamera(this.gameObject);



        // print(name);
    }

}
