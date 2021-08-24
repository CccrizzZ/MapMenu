using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDiveOnStart : MonoBehaviour
{

    public float DiveHight;

    public Quaternion DiveRotation;

    public float Duration;
    
    Vector3 StartPosition;
    Quaternion StartRotation;


    public bool DoneRotating;
    public bool DoneMoving;



    void Start()
    {
        // getstarting position
        StartPosition = transform.position;
        StartRotation = transform.rotation;

        // move camera to start position
        transform.position += new Vector3(0, DiveHight, 0);
        transform.rotation = DiveRotation;



        // CameraDive();
        StartCoroutine(LerpCameraPosition(StartPosition, Duration));
    }
    




    void CameraDive()
    {
        StartCoroutine(LerpCameraRotationAndPosition(StartPosition, StartRotation, Duration));
    
    }



    IEnumerator LerpCameraPosition(Vector3 EndPoint, float duration)
    {


        // variables
        float factor = 1f;
        float time = 0f;
        float threshold = 1.0f;
        bool StartedRotation = false;
        
        // get camera start position
        Vector3 StartPoint = transform.position;

        // do the action
        while (time < duration)
        {
            transform.position = Vector3.Lerp(StartPoint, EndPoint, time / duration);
            

            // start rotating camera if low enough
            if (transform.position.y - StartPosition.y <= 10f && !StartedRotation)
            {
                StartCoroutine(LerpCameraRotation(StartRotation, 0.5f));
                StartedRotation = true;

            }


            // start slowing down time when approach
            if (duration - time <= threshold && factor >= 0.05f)
            {
                factor -= 0.012f;
            }

            // time tick
            time += Time.fixedUnscaledDeltaTime * factor;
            

            yield return null;
        }

        // when action is done
        transform.position = EndPoint;
        DoneMoving = true;


    }

    IEnumerator LerpCameraRotation(Quaternion EndValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, EndValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = EndValue;
        DoneRotating = true;
    }


    IEnumerator LerpCameraRotationAndPosition(Vector3 EndPos,Quaternion EndRot, float duration)
    {
        float time = 0;
        

        // get start rotation and position
        Quaternion StartRot = Camera.main.transform.rotation;
        Vector3 StartPos = Camera.main.transform.position;


        // lerp
        while (time < duration)
        {
            Camera.main.transform.rotation = Quaternion.Lerp(StartRot, EndRot, time / duration);
            Camera.main.transform.position = Vector3.Lerp(StartPos, EndPos, time / duration);
            

            time += Time.deltaTime;
            yield return null;
        }



        // get into end state
        Camera.main.transform.rotation = EndRot;
        Camera.main.transform.position = EndPos;
        
        // set flags
        DoneRotating = true;
        DoneMoving = true;

        
    }



}
