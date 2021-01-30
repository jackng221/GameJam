using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    [SerializeField]
    List<string> input = new List<string>();
    [SerializeField]
    List<string> input2 = new List<string>();
    bool isenter = false;
    [SerializeField]
    public GameObject Dialog, conversate, lv1manager, objectmanager;
    GameObject player;
    [SerializeField]
    int isdoor = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isenter == true && Input.GetKeyDown(KeyCode.C) && Dialog.gameObject.activeInHierarchy != true && player.GetComponent<FPSMovement>().ischanging == false && isdoor == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = true;
            for (int i = 0; i < input.Count; i++)
            {
                Dialog.GetComponent<TextControl>().text.Add(input[i]);
                Dialog.GetComponent<TextControl>().type = 0;
            }
            Dialog.gameObject.SetActive(true);
            conversate.SetActive(false);
        }
        else if (isenter == true && Input.GetKeyDown(KeyCode.C) && Dialog.gameObject.activeInHierarchy != true && player.GetComponent<FPSMovement>().ischanging == false && isdoor > 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = true;
            if (isdoor == 1 && lv1manager.GetComponent<Level1Manager>().Level1iswin) {
                for (int i = 0; i < input2.Count; i++)
                {
                    Dialog.GetComponent<TextControl>().text.Add(input2[i]);
                    Dialog.GetComponent<TextControl>().type = 2;
                }
            }else if (isdoor == 2 && objectmanager.GetComponent<Level2Manager>().winLevel2)
            {
                for (int i = 0; i < input2.Count; i++)
                {
                    Dialog.GetComponent<TextControl>().text.Add(input2[i]);
                    Dialog.GetComponent<TextControl>().type = 2;
                }
            }else if (isdoor == 3)
            {
                for (int i = 0; i < input2.Count; i++)
                {
                    Dialog.GetComponent<TextControl>().text.Add(input2[i]);
                    Dialog.GetComponent<TextControl>().type = 2;
                }
            } else {
                for (int i = 0; i < input.Count; i++)
                {
                    Dialog.GetComponent<TextControl>().text.Add(input[i]);
                    Dialog.GetComponent<TextControl>().type = 0;
                }
            }
            Dialog.gameObject.SetActive(true);
            conversate.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Dialog.gameObject.activeInHierarchy == false)
            {
                conversate.SetActive(true);
            }
            isenter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            conversate.SetActive(false);
            isenter = false;
        }
    }
}
