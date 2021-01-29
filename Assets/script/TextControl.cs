using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    float time = 0;
    public List<string> text = new List<string>();
    int frame = 0;
    public int pointer = 0;
    public int pressed = 0;
    [SerializeField]
    Text textfield, hintcontinue;
    [SerializeField]
    GameObject DialogCanvas, Blur;
    [SerializeField]
    int Switch = 0;
    [SerializeField]
    AudioSource typing;
    // Start is called before the first frame update
    void Start()
    {
        hintcontinue.gameObject.SetActive(false);
        /*TextChanger.onClick.AddListener(() =>
        {
            if (pressed < (text.Count - 1))
            {
                pressed++;
            }
            else
            {
                GameObject.Find("Axis").GetComponent<Conversation>().conversationCanvas.gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = false;
                frame = 0;
                pressed = 0;
            }
            pointer = 0;
            textfield.text = "";
        });*/
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy) {
            Blur.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.C)) {
                if (pressed < (text.Count - 1))
                {
                    pressed++;
                }
                else
                {
                    DialogCanvas.gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<FPSMovement>().ismenuopen = false;
                    frame = 0;
                    pressed = 0;
                    text.Clear();
                    Blur.gameObject.SetActive(false);
                }
                hintcontinue.gameObject.SetActive(false);
                hintcontinue.color = new Color32(50, 50, 50, 255);
                pointer = 0;
                textfield.text = "";
        }

        if (text.Count != 0)
        {
            if (pointer < text[pressed].Length)
            {
                frame++;
                if (frame % 2 == 0)
                {
                    textfield.text += text[pressed][pointer];
                    typing.Play();
                    pointer++;
                }
            }
            else
                hintcontinue.gameObject.SetActive(true);
        }
    }
}
