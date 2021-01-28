using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public List<ObjectManager.LightColor> colorlist = new List<ObjectManager.LightColor>();
    [SerializeField]
    GameObject hideobject;
    public bool iscolor1on = false, iscolor2on = false;
    public ObjectManager.LightColor color1,color2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < colorlist.Count; i++)
        {
            if (colorlist[i] == color1)
            {
                iscolor1on = true;
                break;
            }
            else
                iscolor1on = false;
        }
        for (int i = 0; i < colorlist.Count; i++) {
            if (colorlist[i] == color2)
            {
                iscolor2on = true;
                break;
            }
            else
                iscolor2on = false;
        }
        if (colorlist.Count == 0) {
            iscolor1on = false;
            iscolor2on = false;
        }
        if (iscolor1on == true && iscolor2on == true)
        {
            hideobject.GetComponent<ObjectColor>().isstart_fadeout = false;
        }
        else
        {
            hideobject.GetComponent<ObjectColor>().isstart_fadeout = true;
        }
    }

    
}
