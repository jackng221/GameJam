using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    [SerializeField]
    List<string> input = new List<string>();
    bool isenter = false;
    [SerializeField]
    GameObject Dialog, conversate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isenter == true && Input.GetKeyDown(KeyCode.C) && Dialog.gameObject.activeInHierarchy != true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = true;
            for (int i = 0; i < input.Count; i++)
            {
                Dialog.GetComponent<TextControl>().text.Add(input[i]);
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
