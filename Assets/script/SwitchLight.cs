#if (UNITY_EDITOR) 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    int lightstat = 0;
    [SerializeField]
    GameObject LightSource;
    [SerializeField]
    AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameObject.FindGameObjectWithTag("Player").GetComponent<SetCull>().isgetLight == true) {
            //if (LightSource.GetComponent<ShootShphere>().prevHitObj != null) {
            //    LightSource.GetComponent<ShootShphere>().prevHitObj.GetComponent<mixColorObj>().receiveColor.;
            //}
            click.Play();
            lightstat++;
            lightstat = lightstat % 5;
            switch (lightstat) {
                case 0:
                    LightSource.GetComponent<ShootShphere>().owncolor = ObjectManager.LightColor.Black;
                    break;
                case 1:
                    LightSource.GetComponent<ShootShphere>().owncolor = ObjectManager.LightColor.White;
                    break;
                case 2:
                    LightSource.GetComponent<ShootShphere>().owncolor = ObjectManager.LightColor.Magenta;
                    break;
                case 3:
                    LightSource.GetComponent<ShootShphere>().owncolor = ObjectManager.LightColor.Cyan;
                    break;
                case 4:
                    LightSource.GetComponent<ShootShphere>().owncolor = ObjectManager.LightColor.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
#endif