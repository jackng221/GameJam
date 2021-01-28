using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> RedObject = new List<GameObject>();
    public List<GameObject> GreenObject = new List<GameObject>();
    public List<GameObject> BlueObject= new List<GameObject>();
    public List<GameObject> MagentaObject = new List<GameObject>();
    public List<GameObject> CyanObject = new List<GameObject>();
    public List<GameObject> YellowObject = new List<GameObject>();
    [SerializeField]
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("RedObject"))
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("RedObject");
            for (int i = 0; i < temp.Length; i++)
            {
                RedObject.Add(temp[i]);
            }
        }
        if (GameObject.FindGameObjectWithTag("BlueObject"))
        {
            GameObject[] temp2 = GameObject.FindGameObjectsWithTag("BlueObject");
            for (int i = 0; i < temp2.Length; i++)
            {
                BlueObject.Add(temp2[i]);
            }
        }
        if (GameObject.FindGameObjectWithTag("GreenObject"))
        {
            GameObject[] temp3 = GameObject.FindGameObjectsWithTag("GreenObject");
            for (int i = 0; i < temp3.Length; i++)
            {
                GreenObject.Add(temp3[i]);
            }
        }

        if (GameObject.FindGameObjectWithTag("MagentaObject"))
        {
            GameObject[] temp4 = GameObject.FindGameObjectsWithTag("MagentaObject");
            for (int i = 0; i < temp4.Length; i++)
            {
                MagentaObject.Add(temp4[i]);
            }
        }
        if (GameObject.FindGameObjectWithTag("CyanObject"))
        {
            GameObject[] temp5 = GameObject.FindGameObjectsWithTag("CyanObject");
            for (int i = 0; i < temp5.Length; i++)
            {
                CyanObject.Add(temp5[i]);
            }
        }
        if (GameObject.FindGameObjectWithTag("YellowObject"))
        {
            GameObject[] temp6 = GameObject.FindGameObjectsWithTag("YellowObject");
            for (int i = 0; i < temp6.Length; i++)
            {
                YellowObject.Add(temp6[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<SetCull>().iscomplete == true)
        {
            switch (player.GetComponent<SetCull>().stat)
            {
                case 0:
                    for (int i = 0; i < RedObject.Count; i++)
                    {
                        RedObject[i].SetActive(true);
                    }
                    for (int i = 0; i < GreenObject.Count; i++)
                    {
                        GreenObject[i].SetActive(true);
                    }
                    for (int i = 0; i < BlueObject.Count; i++)
                    {
                        BlueObject[i].SetActive(true);
                    }
                    break;
                case 1:
                    for (int i = 0; i < RedObject.Count; i++)
                    {
                        RedObject[i].SetActive(false);
                    }
                    for (int i = 0; i < YellowObject.Count; i++)
                    {
                        if (YellowObject[i].GetComponent<RecieveColor>().iscolor2on == true)
                        {
                            YellowObject[i].transform.GetChild(0).gameObject.SetActive(false);
                            YellowObject[i].GetComponent<RecieveColor>().istrigger = true;
                        }
                    }
                    for (int i = 0; i < MagentaObject.Count; i++)
                    {
                        if (MagentaObject[i].GetComponent<RecieveColor>().iscolor1on == true)
                        {
                            MagentaObject[i].transform.GetChild(0).gameObject.SetActive(false);
                            MagentaObject[i].GetComponent<RecieveColor>().istrigger = true;
                        }
                    }
                    for (int i = 0; i < MagentaObject.Count; i++)
                    {
                        if (YellowObject[i].GetComponent<RecieveColor>().iscolor1on)
                        {
                            YellowObject[i].SetActive(false);
                        }
                    }
                    for (int i = 0; i < GreenObject.Count; i++)
                    {
                        GreenObject[i].SetActive(true);
                    }
                    for (int i = 0; i < BlueObject.Count; i++)
                    {
                        BlueObject[i].SetActive(true);
                    }
                    break;
                case 2:
                    for (int i = 0; i < GreenObject.Count; i++)
                    {
                        GreenObject[i].SetActive(false);
                    }
                    for (int i = 0; i < YellowObject.Count; i++)
                    {
                        if (YellowObject[i].GetComponent<RecieveColor>().iscolor1on == true)
                        {
                            YellowObject[i].transform.GetChild(0).gameObject.SetActive(false);
                            YellowObject[i].GetComponent<RecieveColor>().istrigger = true;
                        }
                    }
                    for (int i = 0; i < CyanObject.Count; i++)
                    {
                        if (CyanObject[i].GetComponent<RecieveColor>().iscolor2on == true)
                        {
                            CyanObject[i].transform.GetChild(0).gameObject.SetActive(false);
                            CyanObject[i].GetComponent<RecieveColor>().istrigger = true;
                        }
                    }
                    for (int i = 0; i < RedObject.Count; i++)
                    {
                        RedObject[i].SetActive(true);
                    }
                    for (int i = 0; i < BlueObject.Count; i++)
                    {
                        BlueObject[i].SetActive(true);
                    }
                    break;
                case 3:
                    for (int i = 0; i < BlueObject.Count; i++)
                    {
                        BlueObject[i].SetActive(false);
                    }
                    for (int i = 0; i < CyanObject.Count; i++)
                    {
                        if (CyanObject[i].GetComponent<RecieveColor>().iscolor1on == true)
                        {
                            CyanObject[i].transform.GetChild(0).gameObject.SetActive(false);
                            CyanObject[i].GetComponent<RecieveColor>().istrigger = true;
                        }
                    }
                    for (int i = 0; i < MagentaObject.Count; i++)
                    {
                        if (MagentaObject[i].GetComponent<RecieveColor>().iscolor2on == true)
                        {
                            MagentaObject[i].transform.GetChild(0).gameObject.SetActive(false);
                            MagentaObject[i].GetComponent<RecieveColor>().istrigger = true;
                        }
                    }
                    for (int i = 0; i < GreenObject.Count; i++)
                    {
                        GreenObject[i].SetActive(true);
                    }
                    for (int i = 0; i < RedObject.Count; i++)
                    {
                        RedObject[i].SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
