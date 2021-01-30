using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReadCurrentColor : MonoBehaviour
{
    [SerializeField]
    GameObject FlashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlashLight.GetComponent<ShootShphere>().owncolor == ObjectManager.LightColor.White)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (FlashLight.GetComponent<ShootShphere>().owncolor == ObjectManager.LightColor.Black)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        if (FlashLight.GetComponent<ShootShphere>().owncolor == ObjectManager.LightColor.Magenta) {
            this.gameObject.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
        }
        if (FlashLight.GetComponent<ShootShphere>().owncolor == ObjectManager.LightColor.Cyan)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
        }
        if (FlashLight.GetComponent<ShootShphere>().owncolor == ObjectManager.LightColor.Yellow)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }
    }
}
