using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoverToCursor();
        }
    }
    private void MoverToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool hasHit;
        hasHit = Physics.Raycast(ray, out hitInfo);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hitInfo.point;
        }
    }

    // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);

}
