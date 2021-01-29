using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public ObjectManager.LightColor color;
    bool switchOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            if (switchOn)
            {
                Level2Manager.Instanse.color -= (int)color;
                switchOn = false;
            }
            else
            {
                Level2Manager.Instanse.color += (int)color;
                switchOn = true;
            }
        }
    }
}
