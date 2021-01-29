using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ExposureTest : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    ColorGrading color;
    float duration = 4f, speed = 1f, time;
    bool activate = false;

    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        if (postProcessVolume.sharedProfile.TryGetSettings<ColorGrading>(out color))
        {
            color.postExposure.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activate = true;
            time = Time.time;
        }
        if (activate)
        {
            if (Time.time <= time + duration)
            {
                //color.postExposure.overrideState = true;
                color.postExposure.value = Mathf.Lerp(color.postExposure.value, 12f, Time.deltaTime * speed);
                //Debug.Log("1");
            }
            else
            {
                color.postExposure.value = Mathf.Lerp(color.postExposure.value, 0, Time.deltaTime * speed);
                //Debug.Log("2");
            }

            if (color.postExposure.value <= 0)
            {
                activate = false;
            }
        }
        //Debug.Log(time + " " + (time + duration) + " " + Time.time);
    }
}
