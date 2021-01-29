using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFilter : MonoBehaviour
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
        if (isenter == true && Input.GetKeyDown(KeyCode.I))
        {
            player.GetComponent<SetCull>().isgetfilter = true;
            player = null;
            hint.SetActive(false);
            conversate.SetActive(false);
            isenter = false;
            this.gameObject.SetActive(false);

        }

        if (isenter == true && Input.GetKeyDown(KeyCode.C) && Dialog.gameObject.activeInHierarchy != true && player.GetComponent<FPSMovement>().ischanging == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = true;

            Dialog.GetComponent<TextControl>().text.Add("What is this....A pair of glasses and.... 2 kind of lens...");
            Dialog.GetComponent<TextControl>().text.Add("Humm, it should be some kind of hint on it....What should I do..?");
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
