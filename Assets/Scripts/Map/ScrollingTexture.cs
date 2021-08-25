using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{


    public bool on;

    public bool Y;



    float xOffset;
    float animSpeed;



    Renderer rendererRef;

    void Start()
    {

        
        rendererRef = GetComponent<Renderer>();
        animSpeed = -0.5f;
    }

    void Update()
    {
        



        xOffset = Time.time * animSpeed;

        if (Y)
        {
            rendererRef.material.mainTextureOffset = new Vector2(0, -xOffset);    
        }
        else
        {
            rendererRef.material.mainTextureOffset = new Vector2(xOffset, 0);
        }

        if (xOffset > 1) xOffset -= 1; // This prevents inaccuracies when you go over 1.0



    }


}
