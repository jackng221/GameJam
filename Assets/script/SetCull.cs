using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SetCull : MonoBehaviour
{
    [SerializeField]
    GameObject cam, FlashLight, FlashLightRepresent, Filter, paper1, paper2, blur;
    [SerializeField]
    GameObject axis;
    public int stat = 0;
    [SerializeField]
    Image filter;
    public bool iscomplete = true, isgetLight = false, isgetpaper1 = false, isgetpaper2 = false, isgetfilter = false;
    public static ObjectManager.LightColor currentcolor = ObjectManager.LightColor.White;
    int countpaper1 = 0, countpaper2= 0;
    [SerializeField]
    AudioSource WearGlass;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isgetLight == true)
        {
            FlashLight.gameObject.SetActive(true);
            FlashLightRepresent.gameObject.SetActive(true);
        }
        if (isgetpaper1 == true && Input.GetKeyDown(KeyCode.P) && paper2.activeInHierarchy != true)
        {
            if (paper1.activeInHierarchy)
            {
                blur.gameObject.SetActive(false);
                paper1.gameObject.SetActive(false);
            }
            else {
                blur.gameObject.SetActive(true);
                paper1.gameObject.SetActive(true);
            }
            
        }
        if (isgetpaper2 == true && Input.GetKeyDown(KeyCode.O) && paper1.activeInHierarchy != true)
        {
            if (paper2.activeInHierarchy)
            {
                blur.gameObject.SetActive(false);
                paper2.gameObject.SetActive(false);
            }
            else
            {
                blur.gameObject.SetActive(true);
                paper2.gameObject.SetActive(true);
            }
        }
        if (isgetfilter == true)
        {
            filter.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && iscomplete == true) {
            WearGlass.Play();
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
