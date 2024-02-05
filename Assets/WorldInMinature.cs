using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class WorldInMinature : MonoBehaviour
{
    public GameObject envObj;
    public Transform miniGenPoint;
    public float scaleVal;

    private Transform[] miniObjs;
    private GameObject miniEnvObj;
    private bool isStarted = false;
    // Start is called before the first frame update

    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(1);

        miniEnvObj = Instantiate(envObj, miniGenPoint.position, miniGenPoint.rotation);
        miniEnvObj.transform.localScale = new Vector3 (scaleVal, scaleVal, scaleVal);

        Debug.Log("Scale routine again");

        miniObjs = new Transform[envObj.transform.childCount];

        for(int i = 0; i < envObj.transform.childCount; i++)
        {
            var obj = envObj.transform.GetChild(i);
            obj.GetComponent<XRGrabInteractable>().enabled = false;

            miniObjs[i] = miniEnvObj.transform.GetChild(i);
        }

        isStarted = true;
    }

    void FixedUpdate()
    {
        if (isStarted)
        {

            for(int i = 0; i < envObj.transform.childCount; ++i)
            {
                var obj = envObj.transform.GetChild (i);
                var miniObj = miniObjs[i];
                
                
                    Debug.Log("Mini updated again");
                    if (miniObj.parent != miniEnvObj.transform)
                    {
                        miniObj.parent = miniEnvObj.transform;
                    }
                
               

                obj.localPosition = miniObj.localPosition;
                obj.localRotation = miniObj.localRotation;

                
            }
        }
    }

    void Start()
    {
        StartCoroutine(StartRoutine());
    }
}
