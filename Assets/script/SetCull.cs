using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SetCull : MonoBehaviour
{
    [SerializeField]
    GameObject cam, FlashLight, FlashLightRepresent, Filter, paper1, blur, Hintpaper1, hintfilter;
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
            
        }
        if (isgetpaper1 == true && this.gameObject.GetComponent<FPSMovement>().ismenuopen == false)
        {
            FlashLightRepresent.gameObject.SetActive(true);
            Hintpaper1.gameObject.SetActive(true);
            if (isgetfilter == true) {
                hintfilter.SetActive(true);
            }else
                hintfilter.SetActive(false);
        }
        else
        {
            FlashLightRepresent.gameObject.SetActive(false);
            Hintpaper1.gameObject.SetActive(false);
        }
        if (isgetpaper1 == true && Input.GetKeyDown(KeyCode.K))
        {
            if (paper1.activeInHierarchy)
            {
                FlashLightRepresent.gameObject.SetActive(true);
                Hintpaper1.gameObject.SetActive(true);
                blur.gameObject.SetActive(false);
                paper1.gameObject.SetActive(false);
                this.gameObject.GetComponent<FPSMovement>().ismenuopen = false;
            }
            else {
                FlashLightRepresent.gameObject.SetActive(false);
                Hintpaper1.gameObject.SetActive(false);
                blur.gameObject.SetActive(true);
                paper1.gameObject.SetActive(true);
                this.gameObject.GetComponent<FPSMovement>().ismenuopen = true;
            }
            
        }
        if (isgetfilter == true)
        {
            Filter.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.E) && iscomplete == true && isgetfilter == true) {
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
