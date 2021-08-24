using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationIndicator : MonoBehaviour
{


    [SerializeField] Material Normal;
    [SerializeField] Material Highlight;

    [SerializeField] MapController MController;

    [SerializeField] Light lamp;

    [SerializeField] CicleParticleScript ParticleScript;

    void Start()
    {
        if (lamp.gameObject.activeInHierarchy)
        {
            lamp.gameObject.SetActive(false);
        }
        
    }



    void Update()
    {
        
    }

    
    
    void OnMouseEnter()
    {
        if (MController.IsCamMoving)return;

        // set material to highlight material
        GetComponent<Renderer>().material = Highlight;

        // turn on lamp
        lamp.gameObject.SetActive(true);
        
        // highlight particle system
        ParticleScript.HighlightCircle();


    }


    void OnMouseExit() 
    {
        if (MController.IsCamMoving)return;

        // set material to normal
        GetComponent<Renderer>().material = Normal;

        // turn off lamp
        lamp.gameObject.SetActive(false);

        // highlight particle system
        ParticleScript.NormalCircle();

    }


    void OnMouseDown()
    {
        
        // return if camera is moving
        if (MController.IsCamMoving) return;

        // do the camera zoom if shift is down
        if (!Input.GetKey(KeyCode.LeftShift)) return;

        // pass it to map controller
        MController.StartMovingCamera(gameObject);

        // turn off lamp
        lamp.gameObject.SetActive(false);

    }



}
