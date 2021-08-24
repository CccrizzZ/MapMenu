using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{


    public Material NormalCore;
    public Material HighlightCore;
    public Material NormalBorder;
    public Material HighlightBorder;

    public CameraScript CScript;


    public bool IsCamMoving;

    public bool IsLoading;

    bool DoneRotating;
    bool DoneMoving;


    AsyncOperation AsyncLoad;
    




    void Start()
    {
        IsCamMoving = false;
        IsLoading = true;
        DoneRotating = false;
        DoneMoving = false;

        // AsyncLoad = SceneManager.LoadSceneAsync(1);
        // AsyncLoad.allowSceneActivation = false;

        // LoadScene();
    }

    void Update()
    {

    }

    public void LoadScene()
    {
        StartCoroutine(LoadMainScene());
    }

    public void SwapScene()
    {
        // SceneManager.LoadScene(2);
        AsyncLoad.allowSceneActivation = true;
    }

    
    IEnumerator LoadMainScene()
    {
        // set flag 
        IsLoading = true;


        // async load scene
        // AsyncLoad = SceneManager.LoadSceneAsync("TestScene", LoadSceneMode.Single);
        AsyncLoad = SceneManager.LoadSceneAsync("TestScene");

        AsyncLoad.allowSceneActivation = false;
        
        // wait while scene is loading
        // while (!AsyncLoad.isDone)
        while (AsyncLoad.progress <= 0.9f)
        {
            print(AsyncLoad.progress);
            
            // Camera.main.transform.Translate(new Vector3(0, -0.1f, 0));

            yield return null;
        }
            
        AsyncLoad.allowSceneActivation = true;

    }
    

    public void StartMovingCamera(GameObject target)
    {
        // set flag
        IsCamMoving = true;


        // Camera.main.transform.Translate()
        // look at the target
        // Camera.main.transform.LookAt(target.transform);

        // // get relative position
        // Vector3 relativePos = target.transform.position - Camera.main.transform.position;

        // // get look at rotation
        // Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

        // start lerping rotation
        // StartCoroutine(LerpFunction(rotation, 1.0f));




        // start lerping position
        StartCoroutine(LerpCameraPosition(target.transform.position + new Vector3(0f, 0.5f, 0f), 5.0f));
        


        // move towards it
        // StartCoroutine(MoveCam(target));

    }



    IEnumerator MoveCam(GameObject target)
    {
        // start loading scene when clicked
        LoadScene();
        
        // move camera
        while (Vector3.Distance(Camera.main.transform.position, target.transform.position) >= 10.0f)
        {
            if (DoneRotating)
            {
                Camera.main.transform.Translate(Vector3.forward * Time.deltaTime * 100.0f);
                
            }
            
            
            yield return null;
        }

        // after camera is in position swap the scene
        SwapScene();

    }



    IEnumerator LerpFunction(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = Camera.main.transform.rotation;

        while (time < duration)
        {
            Camera.main.transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.rotation = endValue;
        DoneRotating = true;
    }


    IEnumerator LerpCameraPosition(Vector3 EndPoint, float duration)
    {
        // load scene
        LoadScene();

        float time = 0;
        Vector3 StartPoint = Camera.main.transform.position;

        while (time < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(StartPoint, EndPoint, time / duration);
            time += Time.deltaTime;

            yield return null;
        }


        Camera.main.transform.position = EndPoint;
        DoneMoving = true;

        // goto scene
        SwapScene();


    }


}
