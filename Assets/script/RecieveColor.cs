using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveColor : MonoBehaviour
{
    public List<HideObject.LightColor> colorlist = new List<HideObject.LightColor>();
    public HideObject.LightColor wanted, wanted2;
    public bool iscolor1on = false, iscolor2on = false;
    [SerializeField]
    GameObject ActualGameObject;
    GameObject player;

    public bool istrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        switch (this.gameObject.tag) {
            case "YellowObject":
                wanted = HideObject.LightColor.Cyan;
                wanted2 = HideObject.LightColor.Magenta;
                break;
            case "MagentaObject":
                wanted = HideObject.LightColor.Yellow;
                wanted2 = HideObject.LightColor.Cyan;
                break;
            case "CyanObject":
                wanted = HideObject.LightColor.Magenta;
                wanted2 = HideObject.LightColor.Yellow;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < colorlist.Count; i++)
        {
            if (colorlist[i] == wanted)
            {
                iscolor1on = true;
                break;
            }
            else
                iscolor1on = false;
        }
        if (iscolor1on == false)
        {
            for (int i = 0; i < colorlist.Count; i++)
            {
                if (colorlist[i] == wanted2)
                {
                    iscolor2on = true;
                    break;
                }
                else
                    iscolor2on = false;
            }
        }

        switch (this.gameObject.tag)
        {
            case "YellowObject":
                    if((player.GetComponent<SetCull>().currentcolor != HideObject.LightColor.Red && iscolor2on != true) || (player.GetComponent<SetCull>().currentcolor != HideObject.LightColor.Green && iscolor1on != true))
                    ActualGameObject.gameObject.SetActive(true);
                break;
            case "MagentaObject":
                if ((player.GetComponent<SetCull>().currentcolor != HideObject.LightColor.Red && iscolor1on != true) || (player.GetComponent<SetCull>().currentcolor != HideObject.LightColor.Blue && iscolor2on != true))
                    ActualGameObject.gameObject.SetActive(true);
                break;
            case "CyanObject":
                if ((player.GetComponent<SetCull>().currentcolor != HideObject.LightColor.Green && iscolor2on != true) || (player.GetComponent<SetCull>().currentcolor != HideObject.LightColor.Blue && iscolor1on != true))
                    ActualGameObject.gameObject.SetActive(true);
                break;
            default:
                break;
        }


    }
}
