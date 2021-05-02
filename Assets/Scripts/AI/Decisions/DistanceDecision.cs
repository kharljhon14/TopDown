using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class DistanceDecision : AIDecision
    {
        [field: SerializeField] [field: Range(.1f, 10f)] public float Distance { get; set; } = 5f;

        public override bool MakeADecision()
        {
            if(Vector3.Distance(enemyBrain.Target.transform.position, transform.position) < Distance)
            {
                if (!aiActionData.TargetSpotted)
                    aiActionData.TargetSpotted = true;
            }

            else
                aiActionData.TargetSpotted = false;

            return aiActionData.TargetSpotted;
        }

        protected void OnDrawGizmos()
        {
            if(UnityEditor.Selection.activeObject == gameObject)
            {
                Gizmos.color = Color.yellow;

                Gizmos.DrawWireSphere(transform.position, Distance);

                Gizmos.color = Color.white;
            }
        }
    }
}
