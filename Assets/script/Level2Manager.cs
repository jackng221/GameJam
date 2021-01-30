using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    static Level2Manager instance;
    public static Level2Manager Instanse{
        get 
        {
            return instance;
        }
    }

    public GameObject player;
    public int color = 7;
    int prevColor = 0;
    [SerializeField]
    GameObject LightDoor;
    [SerializeField]
    Transform nextLevelStartPoint;
    public bool winLevel2 = false;
    [SerializeField]
    AudioSource unlock;

    Material mat;
    [SerializeField] float speed = 0.15f;
    public GameObject exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        mat = exitDoor.GetComponent<Renderer>().material;
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(prevColor != color)
        {
            switch (color)
            {
            case 0: //white
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                    winLevel2 = true;
                break;
            case 1: //red
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
                break;
            case 2: //green
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 255);
                break;
            case 4: //blue
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(0, 0, 255, 255);
                break;
            case 3: // yellow
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(255, 255, 0, 255);
                break;
            case 5: //magenta
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(255, 0, 255, 255);
                break;
            case 6: //cyan
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(0, 255, 255, 255);
                break;
            case 7: //black
                    LightDoor.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
                break;
            default:
                break;
            }
            prevColor = color;
        }*/

        if (winLevel2)
        {
            //Dissolve door
            if (mat.GetFloat("_DissolveAmount") < 1)
            {
                float temp = mat.GetFloat("_DissolveAmount") + speed * Time.deltaTime;
                mat.SetFloat("_DissolveAmount", temp);
            }
        }
    }

    public void WinLevel2()
    {
        //player.transform.position = nextLevelStartPoint.position;
        winLevel2 = true;
        unlock.Play();
    }

}
