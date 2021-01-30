using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashAndPaper1 : MonoBehaviour
{
    bool isenter = false;
    [SerializeField]
    GameObject Dialog, hint, conversate, player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isenter == true && Input.GetKeyDown(KeyCode.I) && Dialog.gameObject.activeInHierarchy != true)
        {
            player.GetComponent<SetCull>().isgetLight = true;
            player.GetComponent<SetCull>().isgetpaper1 = true;
            player = null;
            hint.SetActive(false);
            conversate.SetActive(false);
            isenter = false;
            gameObject.transform.parent.gameObject.SetActive(false);

        }

            if (isenter == true && Input.GetKeyDown(KeyCode.C) && Dialog.gameObject.activeInHierarchy != true && player.GetComponent<FPSMovement>().ischanging == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = true;

            Dialog.GetComponent<TextControl>().text.Add("My table.");
            Dialog.GetComponent<TextControl>().text.Add("What are these? A flashlight.. and a paper.");
            Dialog.GetComponent<TextControl>().text.Add("...Something about color blending.");
            Dialog.GetComponent<TextControl>().text.Add("*H at above*");
            Dialog.GetComponent<TextControl>().type = 1;
            Dialog.gameObject.SetActive(true);
            conversate.SetActive(false);
            hint.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            player = other.transform.gameObject;
            if (Dialog.gameObject.activeInHierarchy != true)
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
            player = null;
            hint.SetActive(false);
            conversate.SetActive(false);
            isenter = false;
        }
    }
}
