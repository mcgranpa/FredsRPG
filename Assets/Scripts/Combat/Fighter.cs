using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;

        private void Update()
        {
            if (target == null) return;
            if (!GetIsInRange()) 
            {
                GetComponent<Mover>().MoveTo(target.position);
                //print("not in range");
            }
            else
            {
                GetComponent<Mover>().Stop();
                //print("in range");
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget CombatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = CombatTarget.transform;
            //print("hit");
        }

        public void Cancel()
        {
            target = null;
           // print("cancel");
        }
    }
}

