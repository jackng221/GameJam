using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixColorObj : MonoBehaviour
{
    public ObjectManager.LightColor ObjColor;
    public ObjectManager.LightColor prevColor;
    public ObjectManager.LightColor receiveColor;
    public List<ObjectManager.LightColor> FilterColor = new List<ObjectManager.LightColor>();
    public List<ObjectManager.LightColor> LightColor = new List<ObjectManager.LightColor>();
    public bool colorCorrect = false;
    [SerializeField]
    GameObject ActualGameObject;
    GameObject player;

    public bool istrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        switch (ObjColor) {
            case ObjectManager.LightColor.Yellow:
                FilterColor.Add(ObjectManager.LightColor.Green);
                FilterColor.Add(ObjectManager.LightColor.Red);
                LightColor.Add(ObjectManager.LightColor.Cyan);
                LightColor.Add(ObjectManager.LightColor.Magenta);
                break;
            case ObjectManager.LightColor.Magenta:
                FilterColor.Add(ObjectManager.LightColor.Red);
                FilterColor.Add(ObjectManager.LightColor.Blue);
                LightColor.Add(ObjectManager.LightColor.Yellow);
                LightColor.Add(ObjectManager.LightColor.Cyan);
                break;
            case ObjectManager.LightColor.Cyan:
                FilterColor.Add(ObjectManager.LightColor.Green);
                FilterColor.Add(ObjectManager.LightColor.Blue);
                LightColor.Add(ObjectManager.LightColor.Magenta);
                LightColor.Add(ObjectManager.LightColor.Yellow);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(prevColor != SetCull.currentcolor)
        {
            for(int i=0; i < 2; i++)
            {
                if (SetCull.currentcolor == FilterColor[i]) 
                {
                    if (receiveColor == LightColor[1])
                    {
                        colorCorrect = true;
                        break;
                    }
                    else
                    {
                        colorCorrect = false;
                    }
                }
            }
            prevColor = SetCull.currentcolor;
        }

        if (colorCorrect)
        {
            ActualGameObject.gameObject.SetActive(true);
        }
    }
}
