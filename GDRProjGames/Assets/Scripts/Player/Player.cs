using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedPlayer;

    private Camera mainCamera;
    private NavMeshAgent navMeshAgent;
    private List<Vector3> listPoint = new List<Vector3>();
    private LineRenderer lineRenderer;

    private void Awake()
    {
        mainCamera = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        lineRenderer.positionCount = 0;
    }


    private void Start()
    {
        navMeshAgent.speed = speedPlayer;
        StartCoroutine(IsMoving());
    }


    public void Update()
    {
        //Adding an array of coordinates that the player bumped on the playing field
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                listPoint.Add(hit.point);             
                                
            }            
        }
        //while the player is moving the path is drawn
        if (navMeshAgent.hasPath)
        {
            DrawPath();
        }

    }

    //checks if there are coordinates in the array where the player should move
    private IEnumerator IsMoving() 
    {
        while (true)
        {
            if (listPoint.Count > 0)
            {              

                navMeshAgent.SetDestination(listPoint[0]);


                if (Vector3.Distance(transform.position, navMeshAgent.destination) <= 1)
                {
                    listPoint.RemoveAt(0);
                } 

            }
            yield return new WaitForSeconds(0.1f);
        }

    }

    private void DrawPath()
    {
        lineRenderer.positionCount = navMeshAgent.path.corners.Length;
        lineRenderer.SetPosition(0,transform.position);

        if (navMeshAgent.path.corners.Length<2)
        {
            return;
        }

        for (int i = 1; i < navMeshAgent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(navMeshAgent.path.corners[i].x, navMeshAgent.path.corners[i].y, navMeshAgent.path.corners[i].z);
            lineRenderer.SetPosition(i, pointPosition);
        }
    }
}
