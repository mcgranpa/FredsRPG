using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    bool down;
    //[SerializeField] Transform target;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoverToCursor();
        }
        UpdateAnimator();
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

    private void UpdateAnimator()
    {
        // check out global velocity vs local velocity
        // converts global to local 
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
    
    // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);

}
