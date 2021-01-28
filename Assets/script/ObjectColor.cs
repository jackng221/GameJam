using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectColor : MonoBehaviour
{
    [SerializeField]
    public GameObject hideset;
    [SerializeField]
    byte ap;
    public bool isstart_fadeout = false, isstart_fadein = false;
    [SerializeField]
    byte Minus= 3, Plus = 3;
    // Start is called before the first frame update
    void Start()
    {
        ap = 0;
        if (hideset.GetComponent<Image>())
        {
            Color32 a = new Color(hideset.GetComponent<Image>().color.r, hideset.GetComponent<Image>().color.g, hideset.GetComponent<Image>().color.b);
            hideset.GetComponent<Image>().color = new Color32((byte)a.r, (byte)a.g, (byte)a.b, ap);
        }
        else if (hideset.GetComponent<Text>())
        {
            Color32 a = new Color(hideset.GetComponent<Text>().color.r, hideset.GetComponent<Text>().color.g, hideset.GetComponent<Text>().color.b);
            hideset.GetComponent<Text>().color = new Color32((byte)a.r, (byte)a.g, (byte)a.b, ap);
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (ap <= 255 && ap >= 0 && isstart_fadeout == true && isstart_fadein == false)
            {
                if (ap - Minus <= 0)
                {
                    ap = 0;
                }
                else
                    ap -= Minus;
            }
            if (isstart_fadein == true && ap <= 255 && isstart_fadeout == false)
            {
                if (ap + Plus >= 255)
                {
                    ap = 255;
                }
                else
                    ap += Plus;
            }
        if (hideset.GetComponent<Image>())
        {
            Color32 a = new Color(hideset.GetComponent<Image>().color.r, hideset.GetComponent<Image>().color.g, hideset.GetComponent<Image>().color.b);
            hideset.GetComponent<Image>().color = new Color32((byte)a.r, (byte)a.g, (byte)a.b, ap);
        }
        else if (hideset.GetComponent<Text>())
        {
            Color32 a = new Color(hideset.GetComponent<Text>().color.r, hideset.GetComponent<Text>().color.g, hideset.GetComponent<Text>().color.b);
            hideset.GetComponent<Text>().color = new Color32((byte)a.r, (byte)a.g, (byte)a.b, ap);
        }

    }

}
