using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    //[SerializeField]
    //Button endbtn;

    public void EndGame()
    {
        Debug.Log("EndGame");
        Application.Quit();
    }
}