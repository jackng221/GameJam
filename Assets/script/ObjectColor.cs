using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectColor : MonoBehaviour
{

    [SerializeField]
    public GameObject hideGobj;
    [SerializeField]
    byte ap;
    public bool isstart_fadeout = false;
    [SerializeField]
    byte Minus= 3, Plus = 3;
    Color32 originColor;

    // Start is called before the first frame update
    void Start()
    {
        ap = 0;
        if (hideGobj.GetComponent<Image>())
        {
            Image image = hideGobj.GetComponent<Image>();
            originColor = new Color(image.color.r, image.color.g, image.color.b);
            hideGobj.GetComponent<Image>().color = new Color32((byte)originColor.r, (byte)originColor.g, (byte)originColor.b, ap);
        }
        else if (hideGobj.GetComponent<Text>())
        {
            Text text = hideGobj.GetComponent<Text>();
            originColor = new Color(text.color.r, text.color.g, text.color.b);
            hideGobj.GetComponent<Text>().color = new Color32((byte)originColor.r, (byte)originColor.g, (byte)originColor.b, ap);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ap <= 255 && ap >= 0 && isstart_fadeout == true)
        {
            if (ap - Minus <= 0)
            {
                ap = 0;
            }
            else
                ap -= Minus;
        }
        if (ap <= 255 && isstart_fadeout == false)
        {
            if (ap + Plus >= 255)
            {
                ap = 255;
            }
            else
                ap += Plus;
        }
        if (hideGobj.GetComponent<Image>())
        {
            hideGobj.GetComponent<Image>().color = new Color32((byte)originColor.r, (byte)originColor.g, (byte)originColor.b, ap);
        }
        else if (hideGobj.GetComponent<Text>())
        {
            hideGobj.GetComponent<Text>().color = new Color32((byte)originColor.r, (byte)originColor.g, (byte)originColor.b, ap);
        }

    }

}
