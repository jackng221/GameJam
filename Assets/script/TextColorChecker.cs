using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChecker : MonoBehaviour
{
    [SerializeField]
    public ObjectManager.LightColor TargetColor, Recieved;
    [SerializeField]
    public ObjectManager.LightColor currentcolor;
    public bool isFulfil = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentcolor)
        {
            case ObjectManager.LightColor.Magenta:
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 0, 255, 255);
                break;
            case ObjectManager.LightColor.Cyan:
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 255, 255, 255);
                break;
            case ObjectManager.LightColor.Yellow:
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 255, 0, 255);
                break;
            case ObjectManager.LightColor.Red:
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 0, 0, 255);
                break;
            case ObjectManager.LightColor.Green:
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                break;
            case ObjectManager.LightColor.Blue:
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 0, 255, 255);
                break;
            default:
                break;
        }
        switch (Recieved) {
            case ObjectManager.LightColor.Magenta:
                if (currentcolor == ObjectManager.LightColor.Cyan) {
                    currentcolor = ObjectManager.LightColor.Blue;
                }else if (currentcolor == ObjectManager.LightColor.Yellow)
                {
                    currentcolor = ObjectManager.LightColor.Red;
                }
                break;
            case ObjectManager.LightColor.Cyan:
                if (currentcolor == ObjectManager.LightColor.Magenta)
                {
                    currentcolor = ObjectManager.LightColor.Blue;
                }
                else if (currentcolor == ObjectManager.LightColor.Yellow)
                {
                    currentcolor = ObjectManager.LightColor.Green;
                }
                break;
            case ObjectManager.LightColor.Yellow:
                if (currentcolor == ObjectManager.LightColor.Magenta)
                {
                    currentcolor = ObjectManager.LightColor.Red;
                }
                else if (currentcolor == ObjectManager.LightColor.Cyan)
                {
                    currentcolor = ObjectManager.LightColor.Green;
                }
                break;
            default:
                break;
        }
        if (isFulfil == false)
        {
            if (Recieved == TargetColor)
            {
                isFulfil = true;

            }
            else
            {
                isFulfil = false;
            }
            if (currentcolor == TargetColor) {
                isFulfil = true;
            }
        }
    }
}
