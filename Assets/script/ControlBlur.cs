using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBlur : MonoBehaviour
{
    [SerializeField]
    List<Material> listflow = new List<Material>();
    float time;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 6) {
            if (time != 0) {
                time = Time.timeSinceLevelLoad + 1f;
            }
            count++;
        }
        if (Time.timeSinceLevelLoad >= time) {
            this.gameObject.GetComponent<Image>().material = listflow[count];
            time = 0;
        }
    }
}
