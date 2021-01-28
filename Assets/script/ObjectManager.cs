using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public enum LightColor
    {

        Red = 0, Blue, Green, Magenta, Cyan, Yellow, White, Black
    };

    public List<GameObject> PrimaryColorObjects = new List<GameObject>();
    public List<GameObject> MixColorObjects = new List<GameObject>();
    LightColor prevColor;
    [SerializeField]
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        prevColor = SetCull.currentcolor;
        PrimaryColorObj[] pColorObj = GameObject.FindObjectsOfType<PrimaryColorObj>();
        mixColorObj[] mColorObj = GameObject.FindObjectsOfType<mixColorObj>();
        foreach (PrimaryColorObj Obj in pColorObj)
        {
            PrimaryColorObjects.Add(Obj.gameObject);
        }
        foreach (mixColorObj Obj in mColorObj)
        {
            PrimaryColorObjects.Add(Obj.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(prevColor != SetCull.currentcolor)
        {
            if (SetCull.currentcolor == LightColor.White)
            {
                for (int i = 0; i < PrimaryColorObjects.Count; i++)
                {
                    PrimaryColorObjects[i].SetActive(true);
                }
                for (int i = 0; i < MixColorObjects.Count; i++)
                {
                    MixColorObjects[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < PrimaryColorObjects.Count; i++)
                {
                    if(PrimaryColorObjects[i].GetComponent<PrimaryColorObj>().ObjColor == SetCull.currentcolor)
                    {
                        PrimaryColorObjects[i].SetActive(false);
                    }
                    else { PrimaryColorObjects[i].SetActive(true); }
                }
            }
            prevColor = SetCull.currentcolor;
        }

        
    }
}
