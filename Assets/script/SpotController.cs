using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpotController : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Vector3 targetPosition;
    public NavMeshPath navMeshPath;
    bool hitObect = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshPath = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindGameObjectWithTag("Flashlight").GetComponent<ShootShphere>().owncolor != ObjectManager.LightColor.Black)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("MovableFloor"))
                    {
                        targetPosition = hit.point;

                        if (checkPath())
                        {
                            Agent.SetDestination(targetPosition);
                        }
                        else
                        {
                            Agent.SetDestination(this.transform.position);
                        }
                    }
                }
            }
        }

    }

    bool checkPath()
    {
        Agent.CalculatePath(targetPosition, navMeshPath);
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
