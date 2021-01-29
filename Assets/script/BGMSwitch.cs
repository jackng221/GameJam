using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSwitch : MonoBehaviour
{
    [SerializeField]
    AudioSource bgm1, bgm2, bgm3;
    [SerializeField]
    GameObject lv1manager, objectmanager;
    // Start is called before the first frame update
    void Start()
    {
        switchBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchBGM() {
        if (lv1manager.GetComponent<Level1Manager>().Level1iswin == false && objectmanager.GetComponent<Level2Manager>().winLevel2 == false)
        {
            bgm1.Play();
        }else if (lv1manager.GetComponent<Level1Manager>().Level1iswin == true && objectmanager.GetComponent<Level2Manager>().winLevel2 == false)
        {
            bgm1.Stop();
            bgm2.Play();
        }
        else if (lv1manager.GetComponent<Level1Manager>().Level1iswin == true && objectmanager.GetComponent<Level2Manager>().winLevel2 == true)
        {
            bgm2.Stop();
            bgm3.Play();
        }
    }

    public void stopall() {
        bgm1.Stop();
        bgm2.Stop();
        bgm3.Stop();
    }
}
