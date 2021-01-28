using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixColorObj : MonoBehaviour
{
    public ObjectManager.LightColor ObjColor;
    public ObjectManager.LightColor prevColor;
    public ObjectManager.LightColor receiveColor;
    public ObjectManager.LightColor[] FilterColor = new ObjectManager.LightColor[2];
    public ObjectManager.LightColor[] LightColor = new ObjectManager.LightColor[2];
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
                FilterColor[0] = ObjectManager.LightColor.Green;
                FilterColor[1] = ObjectManager.LightColor.Red;
                LightColor[0] = ObjectManager.LightColor.Cyan;
                LightColor[1] = ObjectManager.LightColor.Magenta;
                break;
            case ObjectManager.LightColor.Magenta:
                FilterColor[0] = ObjectManager.LightColor.Red;
                FilterColor[1] = ObjectManager.LightColor.Blue;
                LightColor[0] = ObjectManager.LightColor.Yellow;
                LightColor[1] = ObjectManager.LightColor.Cyan;
                break;
            case ObjectManager.LightColor.Cyan:
                FilterColor[0] = ObjectManager.LightColor.Green;
                FilterColor[1] = ObjectManager.LightColor.Blue;
                LightColor[0] = ObjectManager.LightColor.Magenta;
                LightColor[1] = ObjectManager.LightColor.Yellow;
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
