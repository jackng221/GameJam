using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTest : MonoBehaviour
{
    Material mat;
    [SerializeField] float speed = 0.15f;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (GetComponent<Collider>())
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mat.GetFloat("_DissolveAmount") < 1)
        {
            float temp = mat.GetFloat("_DissolveAmount") + speed * Time.deltaTime;
            //float temp = Mathf.Lerp(mat.GetFloat("_DissolveAmount"), 1, Time.deltaTime * 1);

            mat.SetFloat("_DissolveAmount", temp);
        }

        //Debug.Log(mat.GetFloat("_DissolveAmount"));
    }
}