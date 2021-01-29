using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    [SerializeField]
    public Text textcontinue;
    byte ap;
    bool Down = true;
    // Start is called before the first frame update
    void Start()
    {
        ap = 255;
    }

    // Update is called once per frame
    void Update()
    {
        if (ap <= 255 && ap > 0 && Down == true)
        {
            ap -=3;
        }
        else
            Down = false;
        if (Down == false && ap < 255)
        {
            ap +=3;
        }
        else
            Down = true;
        textcontinue.color = new Color32(50, 50, 50, ap);
    }
}
