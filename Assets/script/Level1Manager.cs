using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] win = new GameObject[3];
    [SerializeField]
    public Text[] threetext = new Text[3];
    bool Level1iswin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (win[0].GetComponent<TextColorChecker>().isFulfil == true)
        {
            threetext[0].color = new Color(threetext[0].color.r, threetext[0].color.g, threetext[0].color.b, 1);
        }
        else
            threetext[0].color = new Color32(0, 0, 255, 90);

        if (win[1].GetComponent<TextColorChecker>().isFulfil == true)
        {
            threetext[1].color = new Color(threetext[1].color.r, threetext[1].color.g, threetext[1].color.b, 1);
        }
        else
            threetext[1].color = new Color32(255, 0, 0, 90);
        if (win[2].GetComponent<TextColorChecker>().isFulfil == true)
        {
            threetext[2].color = new Color(threetext[2].color.r, threetext[2].color.g, threetext[2].color.b, 1);
        }
        else
            threetext[2].color = new Color32(0, 255, 0, 90);


        if (win[0].GetComponent<TextColorChecker>().isFulfil == true && win[2].GetComponent<TextColorChecker>().isFulfil == true && win[1].GetComponent<TextColorChecker>().isFulfil == true) {
            Level1iswin = true;
        }
        if (Level1iswin) {
            Debug.Log("You Win");
        }
    }
}
