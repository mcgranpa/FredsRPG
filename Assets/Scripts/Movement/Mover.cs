using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        bool down;
        //[SerializeField] Transform target;
        void Update()
        {
            UpdateAnimator();
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
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
}