using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{

    float max = 60;
    float min = 1f;

    Light SpotLight;

    float time;
    float speed;

    bool running = true;


    void Start()
    {
        SpotLight = GetComponent<Light>();    
        speed = Random.Range(0f, 0.8f);

        // start lerp light
        // StartCoroutine(StartBlink());
    }

    void Update()
    {
        if (running)
        {
            time = Mathf.PingPong(Time.time * speed, 1f);
            SpotLight.intensity = Mathf.Lerp(max, min, time);
            
        }
    }



    // IEnumerator StartBlink()
    // {
    //     yield return new WaitForSeconds(Random.Range(0f, 6f));
    //     running = true;
    // }



}
