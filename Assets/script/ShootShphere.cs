#if (UNITY_EDITOR) 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShphere : MonoBehaviour
{
    public bool haveme = false;
    public GameObject prevHitObj = null;
    LayerMask mask, layerMask;
    public ObjectManager.LightColor owncolor;
    public bool selection = false;
    public GameObject player, fire;
    [SerializeField]
    float speed = 1.0f;
    float step;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("HideWord");
        player = GameObject.FindGameObjectWithTag("Player");
        fire = GameObject.FindGameObjectWithTag("Fire");
        layerMask = LayerMask.GetMask("Invisible");
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
        RaycastHit hit, hit2;
        Vector3 pos = this.gameObject.transform.position;
        
        if (Physics.SphereCast(pos, this.gameObject.GetComponent<Light>().shadowRadius, transform.forward, out hit,Mathf.Infinity)) {
            //Reset Color from prev, (Situation of change hit target)
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
                    prevHitObj.GetComponent<mixColorObj>().receiveColor = ObjectManager.LightColor.White;
                }
                prevHitObj = null;
                haveme = false;
            }

            //Insert Color
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

            if (hit.transform.tag == "Finish") {
                hit.transform.GetComponent<TextColorChecker>().Recieved = owncolor;
            }
        }
        else if (prevHitObj != null)
        {
            //Reset Color from prev, (Situation of hit null)
            if (prevHitObj.transform.tag == "HideWord")
            {
                for (int i = 0; i < prevHitObj.GetComponent<HideObject>().colorlist.Count; i++)
                {
                    if (prevHitObj.GetComponent<HideObject>().colorlist[i] == owncolor)
                    {
                        prevHitObj.GetComponent<HideObject>().colorlist.Remove(prevHitObj.GetComponent<HideObject>().colorlist[i]);
                    }
                }
            }else if (prevHitObj.GetComponent<mixColorObj>())
                {
                    prevHitObj.GetComponent<mixColorObj>().receiveColor = ObjectManager.LightColor.White;
                }
            prevHitObj = null;
            haveme = false;
        }
        if (owncolor != ObjectManager.LightColor.Black) {
            if (Physics.Raycast(pos, transform.forward, out hit2, Mathf.Infinity, layerMask))
            {

                if (hit2.transform.tag == "Fire")
                {
                    Debug.Log("Active");
                    selection = true;
                }
                else
                {
                    Debug.Log("DisActive");
                    selection = false;
                }

            }
            else
                selection = false;
        }

        if (selection == true) {
            step = speed * Time.deltaTime;
            fire.transform.position = Vector3.MoveTowards(fire.transform.position, new Vector3(player.transform.position.x, fire.transform.position.y, player.transform.position.z), step);
        }
    }

}

#endif