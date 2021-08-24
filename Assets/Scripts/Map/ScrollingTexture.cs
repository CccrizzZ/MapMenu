using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{


    public bool on;
    float xOffset;
    float animSpeed;

    Renderer rendererRef;

    void Start()
    {
        rendererRef = GetComponent<Renderer>();
        animSpeed = 0.5f;
    }

    void Update()
    {
        xOffset = Time.time * animSpeed;
        rendererRef.material.mainTextureOffset = new Vector2(xOffset, xOffset);
        if (xOffset > 1) xOffset -= 1; // This prevents inaccuracies when you go over 1.0
            
    }
}
