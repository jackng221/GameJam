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
    public bool Level1iswin = false;
    public bool once = false;
    [SerializeField]
    AudioSource unlock;
    [SerializeField]
    GameObject resetbtn;

    Material mat;
    [SerializeField] float speed = 0.15f;
    public GameObject exitDoor;
    // Start is called before the first frame update
    void Start()
    {
        mat = exitDoor.GetComponent<Renderer>().material;
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


        if (win[0].GetComponent<TextColorChecker>().isFulfil == true && win[2].GetComponent<TextColorChecker>().isFulfil == true && win[1].GetComponent<TextColorChecker>().isFulfil == true)
        {
            //Dissolve door
            if (mat.GetFloat("_DissolveAmount") < 1)
            {
                float temp = mat.GetFloat("_DissolveAmount") + speed * Time.deltaTime;
                mat.SetFloat("_DissolveAmount", temp);
            }

            Level1iswin = true;
        }
        else
            Level1iswin = false;
        if (Level1iswin && once == false) {
            resetbtn.SetActive(false);
            once = true;
            unlock.Play();
        }
    }
}
