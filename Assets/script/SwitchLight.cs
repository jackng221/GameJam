using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    int lightstat = 0;
    [SerializeField]
    GameObject LightSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            if (LightSource.GetComponent<ShootShphere>().temp != null) {
                LightSource.GetComponent<ShootShphere>().temp.GetComponent<RecieveColor>().colorlist.Clear();
                LightSource.GetComponent<ShootShphere>().temp.GetComponent<RecieveColor>().iscolor1on = false;
                LightSource.GetComponent<ShootShphere>().temp.GetComponent<RecieveColor>().iscolor2on = false;
            }
            lightstat++;
            lightstat = lightstat % 5;
            switch (lightstat) {
                case 0:
                    LightSource.GetComponent<ShootShphere>().owncolor = HideObject.LightColor.Black;
                    break;
                case 1:
                    LightSource.GetComponent<ShootShphere>().owncolor = HideObject.LightColor.White;
                    break;
                case 2:
                    LightSource.GetComponent<ShootShphere>().owncolor = HideObject.LightColor.Magenta;
                    break;
                case 3:
                    LightSource.GetComponent<ShootShphere>().owncolor = HideObject.LightColor.Cyan;
                    break;
                case 4:
                    LightSource.GetComponent<ShootShphere>().owncolor = HideObject.LightColor.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
