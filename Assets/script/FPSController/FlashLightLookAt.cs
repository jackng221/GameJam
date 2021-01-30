using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashLightLookAt : MonoBehaviour
{
    public GameObject flashLightObj;
    public Camera cam;
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)){
            flashLightObj.transform.DOLookAt(hit.point, 0.5f);
        }
        //else
        //{
        //    flashLightObj.transform.DOLookAt(cam.transform.forward, 0.5f);
        //}
    }
}
