using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        public override void Attack(int damage)
        {
            if (!waitForNextAttack)
            {
                IHitable hittable = GetTarget().GetComponent<IHitable>();
                hittable?.GetHit(damage, gameObject);
                StartCoroutine(WaitForNextAttackCoroutine());
            }
        }
    }
}