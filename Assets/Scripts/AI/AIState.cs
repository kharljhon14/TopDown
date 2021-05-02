using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class AIState : MonoBehaviour
    {
        private EnemyBrain enemyBrain = null;

        [SerializeField] private List<AIAction> actions = null;
        [SerializeField] private List<AITransition> transitions = null;

        private void Awake()
        {
            enemyBrain = transform.root.GetComponent<EnemyBrain>();
        }

        public void UpdateState()
        {
            foreach (AIAction action in actions)
            {
                action.TakeAction();
            }

            foreach (AITransition transition in transitions)
            {
                //player in range -> true -> back to idle
                //player visible -> true -> chase

                bool result = false;

                foreach (AIDecision decision in transition.Decisions)
                {
                    result = decision.MakeADecision();

                    if (!result)
                        break;
                }

                if (result)
                {
                    if(transition.PositiveResult != null)
                    {
                        enemyBrain.ChangeToState(transition.PositiveResult);
                        return;
                    }
                }

                else
                {
                    if(transition.NegativeResult != null)
                    {
                        enemyBrain.ChangeToState(transition.NegativeResult);
                        return;
                    }
                }
            }
        }
    }
}