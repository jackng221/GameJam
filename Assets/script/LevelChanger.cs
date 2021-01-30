using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelChanger : MonoBehaviour
{
    public bool isenter = false;
    [SerializeField]
    GameObject move, player, lv1manager, objectmanager, level3sp, level2sp, bgmchanger;
    [SerializeField]
    int level = 1;
    [SerializeField]
    Image Switching, wining;
    [SerializeField]
    Text Wintext;
    [SerializeField]
    Button GameEnd;
    [SerializeField]
    AudioSource GameEndBGM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (isenter == true && Input.GetKeyDown(KeyCode.O) && this.gameObject.GetComponent<PlayerEnter>().Dialog.gameObject.activeInHierarchy != true)
            {
                if (level == 1 && lv1manager.GetComponent<Level1Manager>().Level1iswin == true)
                {
                    bgmchanger.GetComponent<BGMSwitch>().switchBGM();
                    player.GetComponent<FPSMovement>().ischanging = true;
                    player.GetComponent<FPSMovement>().ismenuopen = true;
                    Switching.DOColor(new Color32(255, 255, 255, 255), 2f).OnComplete(() => {
                        player.transform.position = level2sp.transform.position;
                        Switching.color = new Color32(255, 255, 255, 0);
                        if (player.transform.position == level2sp.transform.position) {
                            player.GetComponent<FPSMovement>().ischanging = false;
                            player.GetComponent<FPSMovement>().ismenuopen = false;
                        }
                        
                    });
                }

            if (level == 2 && objectmanager.GetComponent<Level2Manager>().winLevel2 == true)
            {
                bgmchanger.GetComponent<BGMSwitch>().switchBGM();
                player.GetComponent<FPSMovement>().ischanging = true;
                player.GetComponent<FPSMovement>().ismenuopen = true;
                Switching.DOColor(new Color32(255, 255, 255, 255), 2f).OnComplete(() => {
                    player.transform.position = level3sp.transform.position;
                    Switching.color = new Color32(255, 255, 255, 0);
                    player.GetComponent<FPSMovement>().ischanging = false;
                    player.GetComponent<FPSMovement>().ismenuopen = false;
                    if (player.transform.position == level3sp.transform.position)
                    {
                        player.GetComponent<FPSMovement>().ischanging = false;
                        player.GetComponent<FPSMovement>().ismenuopen = false;
                    }
                });
            }
            if (level == 3)
            {
                bgmchanger.GetComponent<BGMSwitch>().stopall();
                GameEndBGM.Play();
                player.GetComponent<FPSMovement>().ischanging = true;
                    wining.DOColor(new Color32(255, 255, 255, 255), 2f).OnComplete(() => {
                        GameEnd.gameObject.SetActive(true);
                        Wintext.gameObject.SetActive(true);
                        player.GetComponent<FPSMovement>().ismenuopen = true;
                        player.GetComponent<FPSMovement>().ischanging = true;
                    });
            }
        }
        if (this.gameObject.GetComponent<PlayerEnter>().Dialog.gameObject.activeInHierarchy == true) {
            move.SetActive(false);

        }

    }
         

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            player = other.gameObject;
            if (this.gameObject.GetComponent<PlayerEnter>().Dialog.gameObject.activeInHierarchy == false && ((level==1 && lv1manager.GetComponent<Level1Manager>().Level1iswin == true) || (level==2 && objectmanager.GetComponent<Level2Manager>().winLevel2 == true) || level == 3) && player.GetComponent<FPSMovement>().ismenuopen == false)
            {

                move.SetActive(true);
            }
            else
                move.SetActive(false);
            isenter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
        if (this.gameObject.GetComponent<PlayerEnter>().Dialog.gameObject.activeInHierarchy == false && (lv1manager.GetComponent<Level1Manager>().Level1iswin == true || objectmanager.GetComponent<Level2Manager>().winLevel2 == true || level == 3))
        {

            move.SetActive(false);
        }
        isenter = false;
    }
}
