using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SetCull : MonoBehaviour
{
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject axis;
    public int stat = 0;
    [SerializeField]
    Image filter;
    public bool iscomplete = true;
    public static ObjectManager.LightColor currentcolor = ObjectManager.LightColor.White;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iscomplete == true) {
            iscomplete = false;
            stat += 1;
            stat = stat % 4;
            if (stat == 0)
            {
                currentcolor = ObjectManager.LightColor.White;
                filter.color = new Color32(255, 255, 255, 0);
                axis.transform.DOLocalRotate(new Vector3(0, 0, -90), 0.5f).OnComplete(() =>
                {
                    iscomplete = true;
                    cam.GetComponent<Camera>().cullingMask = LayerMask.NameToLayer("Everything");
                });
            }
            else if (stat == 1)
            {
                filter.color = new Color32(255, 0, 0, 75);
                currentcolor = ObjectManager.LightColor.Red;
                axis.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
                {
                    iscomplete = true;
                    cam.GetComponent<Camera>().cullingMask = ~(1 << LayerMask.NameToLayer("RedObject"));
                });

            }
            else if (stat == 2)
            {
                axis.transform.DOLocalRotate(new Vector3(0, 0, -90), 1f).OnComplete(() =>
                {
                    filter.color = new Color32(0, 255, 0, 75);
                    currentcolor = ObjectManager.LightColor.Green;
                    axis.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => {
                        cam.GetComponent<Camera>().cullingMask = ~(1 << LayerMask.NameToLayer("GreenObject"));
                        iscomplete = true;
                    });
                });
            }
            else if (stat == 3) {
                axis.transform.DOLocalRotate(new Vector3(0, 0, -90), 1f).OnComplete(() =>
                {
                    filter.color = new Color32(0, 0, 255, 75);
                    currentcolor = ObjectManager.LightColor.Blue;
                    axis.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => {
                        cam.GetComponent<Camera>().cullingMask = ~(1 << LayerMask.NameToLayer("BlueObject"));
                        iscomplete = true;
                    });
                });
                
                
            }
        }
    }
}
