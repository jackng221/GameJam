using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DOF_Update : MonoBehaviour
{
    float currentHitDistance;
    private PostProcessVolume postProcessVolume;
    DepthOfField dof;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();

    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            currentHitDistance = hit.distance;
        }
        else
        {
            currentHitDistance = 10;
        }
        if (postProcessVolume)
        {
            if (postProcessVolume.sharedProfile.TryGetSettings<DepthOfField>(out dof)){
                dof.focusDistance.value = Mathf.Lerp(dof.focusDistance.value, currentHitDistance, Time.deltaTime * 1.5f);
            }
        }
    }
}
