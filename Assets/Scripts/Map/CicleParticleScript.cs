using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicleParticleScript : MonoBehaviour
{
    ParticleSystem ps;

    
    Gradient NormalGradient;
    Gradient HighLightGradient;


    void Start() 
    {
        ps = GetComponent<ParticleSystem>();
        var col = ps.colorOverLifetime;
        NormalGradient= col.color.gradient;

        Gradient grad = new Gradient();
        grad.SetKeys(
            new GradientColorKey[] 
            { 
                new GradientColorKey(Color.red, 0.0f), 
                new GradientColorKey(Color.red, 1.0f) 
            }, 
            new GradientAlphaKey[] 
            { 
                new GradientAlphaKey(1.0f, 0.0f), 
                new GradientAlphaKey(0.0f, 1.0f) 
            }
        );
        HighLightGradient = grad;

    }

    public void HighlightCircle()
    {
        var col = ps.colorOverLifetime;
        col.color = HighLightGradient;
        
    }


    public void NormalCircle()
    {

        var col = ps.colorOverLifetime;
        col.color = NormalGradient;

    }
}
