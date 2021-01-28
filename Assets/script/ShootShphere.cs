using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShphere : MonoBehaviour
{
    public bool haveme = false;
    public GameObject temp = null;
    LayerMask mask;
    public HideObject.LightColor owncolor;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("HideWord");
    }

    // Update is called once per frame
    void Update()
    {
        switch (owncolor) {
            case HideObject.LightColor.Red:
                this.GetComponent<Light>().color = new Color32(255, 0, 0, 255);
                break;
            case HideObject.LightColor.Green:
                this.GetComponent<Light>().color = new Color32(0, 255, 0, 255);
                break;
            case HideObject.LightColor.Blue:
                this.GetComponent<Light>().color = new Color32(0, 0, 255, 255);
                break;
            case HideObject.LightColor.Magenta:
                this.GetComponent<Light>().color = new Color32(255, 0, 255, 255);
                break;
            case HideObject.LightColor.Cyan:
                this.GetComponent<Light>().color = new Color32(0, 255, 255, 255);
                break;
            case HideObject.LightColor.Yellow:
                this.GetComponent<Light>().color = new Color32(255, 255, 0, 255);
                break;
            case HideObject.LightColor.White:
                this.GetComponent<Light>().color = new Color32(255, 255, 255, 255);
                break;
            case HideObject.LightColor.Black:
                this.GetComponent<Light>().color = new Color32(0, 0, 0, 255);
                break;
            default:
                break;
        }
        RaycastHit hit;
        Vector3 pos = this.gameObject.transform.position;
        
        if (Physics.SphereCast(pos, this.gameObject.GetComponent<Light>().shadowRadius, transform.forward, out hit,10f)) {
            if (temp != hit.transform.gameObject && temp != null) {
                if (temp.transform.tag == "HideWord")
                {
                    for (int i = 0; i < temp.GetComponent<HideObject>().colorlist.Count; i++)
                    {
                        if (temp.GetComponent<HideObject>().colorlist[i] == owncolor)
                        {
                            temp.GetComponent<HideObject>().colorlist.Remove(temp.GetComponent<HideObject>().colorlist[i]);
                        }
                    }
                }
                else if (temp.transform.tag == "YellowObject" || temp.transform.tag == "MagentaObject" || temp.transform.tag == "CyanObject")
                {
                    for (int i = 0; i < temp.GetComponent<RecieveColor>().colorlist.Count; i++)
                    {
                        if (temp.GetComponent<RecieveColor>().colorlist[i] == owncolor)
                        {
                            temp.GetComponent<RecieveColor>().colorlist.Remove(temp.GetComponent<RecieveColor>().colorlist[i]);
                        }
                    }
                    temp.GetComponent<RecieveColor>().istrigger = false;
                    temp.GetComponent<RecieveColor>().iscolor1on = false;
                    temp.GetComponent<RecieveColor>().iscolor2on = false;
                }
                temp = null;
                haveme = false;
            }
            if (hit.transform.tag == "HideWord") {
                temp = hit.transform.gameObject;
                for (int i = 0; i < temp.GetComponent<HideObject>().colorlist.Count; i++) {
                    if (temp.GetComponent<HideObject>().colorlist[i] == owncolor) {
                        haveme = true;
                    }
                }
                if (haveme == false) {
                    temp.GetComponent<HideObject>().colorlist.Add(owncolor);
                }
            }

            if (hit.transform.tag == "YellowObject" || hit.transform.tag == "MagentaObject" || hit.transform.tag == "CyanObject")
            {
                temp = hit.transform.gameObject;
                for (int i = 0; i < temp.GetComponent<RecieveColor>().colorlist.Count; i++)
                {
                    if (temp.GetComponent<RecieveColor>().colorlist[i] == owncolor)
                    {
                        haveme = true;
                    }
                }
                if (haveme == false)
                {
                    temp.GetComponent<RecieveColor>().colorlist.Add(owncolor);
                }
            }
        }
        else if (temp != null)
        {
            if (temp.transform.tag == "HideWord")
            {
                for (int i = 0; i < temp.GetComponent<HideObject>().colorlist.Count; i++)
                {
                    if (temp.GetComponent<HideObject>().colorlist[i] == owncolor)
                    {
                        temp.GetComponent<HideObject>().colorlist.Remove(temp.GetComponent<HideObject>().colorlist[i]);
                    }
                }
            }else if (temp.transform.tag == "YellowObject" || temp.transform.tag == "MagentaObject" || temp.transform.tag == "CyanObject")
                {
                    for (int i = 0; i < temp.GetComponent<RecieveColor>().colorlist.Count; i++)
                    {
                        if (temp.GetComponent<RecieveColor>().colorlist[i] == owncolor)
                        {
                            temp.GetComponent<RecieveColor>().colorlist.Remove(temp.GetComponent<RecieveColor>().colorlist[i]);
                        }
                    }
                    temp.GetComponent<RecieveColor>().istrigger = false;
                    temp.GetComponent<RecieveColor>().iscolor1on = false;
                    temp.GetComponent<RecieveColor>().iscolor2on = false;
                }
            temp = null;
            haveme = false;
        }
    }

}
