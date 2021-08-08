using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class LookDecision : AIDecision
    {
        [SerializeField] [Range(1, 15)]private float distance = 5f;
        [SerializeField] LayerMask raycastMask = new LayerMask();

        [field: SerializeField] public UnityEvent OnPlayerSpotted { get; set; }

        public override bool MakeADecision()
        {
            Vector3 direction = enemyBrain.Target.transform.position - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, raycastMask);

            if(hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                OnPlayerSpotted?.Invoke();
                return true;
            }

            return false;
        }

        //private void OnDrawGizmos()
        //{
        //    if(UnityEditor.Selection.activeObject == gameObject && enemyBrain != null && enemyBrain.Target != null)
        //    {
        //        Gizmos.color = Color.red;
        //        Vector3 direction = enemyBrain.Target.transform.position - transform.position;
        //        Gizmos.DrawRay(transform.position, direction.normalized * distance);

        //        Gizmos.color = Color.white;
        //    }
        //}
    }
}