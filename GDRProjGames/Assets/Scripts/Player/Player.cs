using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //[SerializeField] private GameObject point;
    //private float range = 100f;
    //public List<GameObject> masPoint = new List<GameObject>();

    //.........................................
    //[SerializeField] private Transform movePositionTransform;
    private Camera mainCamera;
    private NavMeshAgent navMeshAgent;
    public List<Vector3> test = new List<Vector3>();
    private int cur;
    private Vector3 curTest;
    private void Awake()
    {
        mainCamera = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                test.Add(hit.point);
                IsMoving();
            }

            
        }
        if (!navMeshAgent.hasPath && test.Count > 0)
        {
            cur++;
            
        }
    }



    private void IsMoving() 
    {

        navMeshAgent.SetDestination(test[cur]);



        


    }


}
