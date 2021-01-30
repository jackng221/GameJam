using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LightDoor : MonoBehaviour
{
    [SerializeField]
    Text clearText;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            clearText.color = new Color32(255, 255, 255, 255);
            this.gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
            if (GameObject.Find("ObjectManager"))
            {
                GameObject.Find("ObjectManager").GetComponent<Level2Manager>().WinLevel2();
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            clearText.color = new Color32(255, 255, 255, 90);
            this.gameObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
            if (GameObject.Find("ObjectManager"))
            {
                GameObject.Find("ObjectManager").GetComponent<Level2Manager>().winLevel2 = false;
            }

        }
    }
}
