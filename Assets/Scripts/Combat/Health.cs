using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            if (health == 0)
            {
                if (!isDead)
                {
                    GetComponent<Animator>().SetTrigger("die");
                    isDead = true;
                }
            }
            print(health);
        }

        public float GetHealth()
        {
            return health;
        }

    }
}