using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBlur : MonoBehaviour
{
    [SerializeField]
    List<Material> listflow = new List<Material>();
    float time;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void ResetCallClearToBlur()
    {
        count = 5;
    }
    public void ResetCallBlurToClear()
    {
        count = 0;
    }
    public void CallBlurToClear() {
        if (count < 6)
        {
            if (time != 0)
            {
                time = Time.timeSinceLevelLoad + 1f;
            }
            count++;
        }
        if (Time.timeSinceLevelLoad >= time && count <= 5)
        {
            this.gameObject.GetComponent<Image>().material = listflow[count];
            time = 0;
        }

    }

    public void CallClearToBlur()
    {
        if (count >=0)
        {
            if (time != 0)
            {
                time = Time.timeSinceLevelLoad + 1f;
            }
            count--;
        }
        if (Time.timeSinceLevelLoad >= time && count >= 0)
        {
            this.gameObject.GetComponent<Image>().material = listflow[count];
            time = 0;
        }
    }
}
