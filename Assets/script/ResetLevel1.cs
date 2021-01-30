using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel1 : MonoBehaviour
{
    public bool isenter=false;
    [SerializeField]
    GameObject GameManager, Dialog, hint, conversate;
    bool istrue = false;
    GameObject player;
    [SerializeField]
    AudioSource buttonclick;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isenter == true && Input.GetKeyDown(KeyCode.I)) {
            buttonclick.Play();
            GameManager.GetComponent<Level1Manager>().win[0].GetComponent<TextColorChecker>().currentcolor = ObjectManager.LightColor.Magenta;
            GameManager.GetComponent<Level1Manager>().win[0].GetComponent<TextColorChecker>().Recieved = ObjectManager.LightColor.White;
            GameManager.GetComponent<Level1Manager>().win[0].GetComponent<TextColorChecker>().isFulfil = false;
            GameManager.GetComponent<Level1Manager>().win[1].GetComponent<TextColorChecker>().currentcolor = ObjectManager.LightColor.Yellow;
            GameManager.GetComponent<Level1Manager>().win[1].GetComponent<TextColorChecker>().Recieved = ObjectManager.LightColor.White;
            GameManager.GetComponent<Level1Manager>().win[1].GetComponent<TextColorChecker>().isFulfil = false;
            GameManager.GetComponent<Level1Manager>().win[2].GetComponent<TextColorChecker>().currentcolor = ObjectManager.LightColor.Cyan;
            GameManager.GetComponent<Level1Manager>().win[2].GetComponent<TextColorChecker>().Recieved = ObjectManager.LightColor.White;
            GameManager.GetComponent<Level1Manager>().win[2].GetComponent<TextColorChecker>().isFulfil = false;
            istrue = false;
        }
        if (isenter == true && Input.GetKeyDown(KeyCode.C) && Dialog.gameObject.activeInHierarchy != true && player.GetComponent<FPSMovement>().ischanging ==false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = true;

            Dialog.GetComponent<TextControl>().text.Add("Why is there a button here..?");
            Dialog.GetComponent<TextControl>().text.Add("Doesn't seem harmful.. maybe something to do with the letters.");
            Dialog.GetComponent<TextControl>().type = 1;
            Dialog.gameObject.SetActive(true);
            conversate.SetActive(false);
            hint.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            if (Dialog.gameObject.activeInHierarchy == false)
            {
                hint.SetActive(true);
                conversate.SetActive(true);
            }
            isenter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            hint.SetActive(false);
            conversate.SetActive(false);
            isenter = false;
        }

    }

}
