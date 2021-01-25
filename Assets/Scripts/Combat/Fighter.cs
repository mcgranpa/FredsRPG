﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;


        Transform target;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
                //print("not in range");
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
                //print("in range");
            }
        }

        private void AttackBehavior()
        {
            Health healthComponent = target.GetComponent<Health>();
            // if (healthComponent.GetHealth() <= 0.5f) return;
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // this will trigger the Hit() event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;

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

        // called from animation Unarmed-Attack-L3
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }
    }
}

