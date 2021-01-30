using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    [SerializeField]
    Button endbtn;
    // Start is called before the first frame update
    void Start()
    {
        endbtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
