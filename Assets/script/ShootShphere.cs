using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShphere : MonoBehaviour
{
    public bool haveme = false;
    public GameObject prevHitObj = null;
    LayerMask mask;
    public ObjectManager.LightColor owncolor;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("HideWord");
    }

    // Update is called once per frame
    void Update()
    {
        switch (owncolor) {
            case ObjectManager.LightColor.Red:
                this.GetComponent<Light>().color = new Color32(255, 0, 0, 255);
                break;
            case ObjectManager.LightColor.Green:
                this.GetComponent<Light>().color = new Color32(0, 255, 0, 255);
                break;
            case ObjectManager.LightColor.Blue:
                this.GetComponent<Light>().color = new Color32(0, 0, 255, 255);
                break;
            case ObjectManager.LightColor.Magenta:
                this.GetComponent<Light>().color = new Color32(255, 0, 255, 255);
                break;
            case ObjectManager.LightColor.Cyan:
                this.GetComponent<Light>().color = new Color32(0, 255, 255, 255);
                break;
            case ObjectManager.LightColor.Yellow:
                this.GetComponent<Light>().color = new Color32(255, 255, 0, 255);
                break;
            case ObjectManager.LightColor.White:
                this.GetComponent<Light>().color = new Color32(255, 255, 255, 255);
                break;
            case ObjectManager.LightColor.Black:
                this.GetComponent<Light>().color = new Color32(0, 0, 0, 255);
                break;
            default:
                break;
        }
        RaycastHit hit;
        Vector3 pos = this.gameObject.transform.position;
        
        if (Physics.SphereCast(pos, this.gameObject.GetComponent<Light>().shadowRadius, transform.forward, out hit,10f)) {

            if (prevHitObj != hit.transform.gameObject && prevHitObj != null) {
                if (prevHitObj.transform.tag == "HideWord")
                {
                    for (int i = 0; i < prevHitObj.GetComponent<HideObject>().colorlist.Count; i++)
                    {
                        if (prevHitObj.GetComponent<HideObject>().colorlist[i] == owncolor)
                        {
                            prevHitObj.GetComponent<HideObject>().colorlist.Remove(prevHitObj.GetComponent<HideObject>().colorlist[i]);
                        }
                    }
                }
                else if (prevHitObj.GetComponent<mixColorObj>())
                {
                    prevHitObj.GetComponent<mixColorObj>().receiveColor = owncolor;
                }
                prevHitObj = null;
                haveme = false;
            }
            if (hit.transform.tag == "HideWord") {
                prevHitObj = hit.transform.gameObject;
                for (int i = 0; i < prevHitObj.GetComponent<HideObject>().colorlist.Count; i++) {
                    if (prevHitObj.GetComponent<HideObject>().colorlist[i] == owncolor) {
                        haveme = true;
                    }
                }
                if (haveme == false) {
                    prevHitObj.GetComponent<HideObject>().colorlist.Add(owncolor);
                }
            }

            if (hit.transform.GetComponent<mixColorObj>())
            {
                prevHitObj = hit.transform.gameObject;
                if (prevHitObj.GetComponent<mixColorObj>().receiveColor == owncolor)
                {
                    haveme = true;
                }
                if (haveme == false)
                {
                    prevHitObj.GetComponent<mixColorObj>().receiveColor = owncolor;
                }
            }
        }
        else if (prevHitObj != null)
        {
            if (prevHitObj.transform.tag == "HideWord")
            {
                for (int i = 0; i < prevHitObj.GetComponent<HideObject>().colorlist.Count; i++)
                {
                    if (prevHitObj.GetComponent<HideObject>().colorlist[i] == owncolor)
                    {
                        prevHitObj.GetComponent<HideObject>().colorlist.Remove(prevHitObj.GetComponent<HideObject>().colorlist[i]);
                    }
                }
            }
            else if (prevHitObj.GetComponent<mixColorObj>())
            {
                prevHitObj.GetComponent<mixColorObj>().receiveColor = ObjectManager.LightColor.White;
            }
            prevHitObj = null;
            haveme = false;
        }
    }

}
