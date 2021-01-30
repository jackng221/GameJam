using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DG.Tweening;


public class LightDoor : MonoBehaviour
{
    [SerializeField]
    Text clearText;
    GameObject glowSpot;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Level2Manager.Instance.winLevel2)
        {
            glowSpot.transform.DOMove(this.gameObject.transform.position, 1f);
        }
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
                other.GetComponent<NavMeshAgent>().enabled = false;
                glowSpot = other.gameObject;
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
