using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class EnemyBrain : MonoBehaviour, IAgentInput
    {
        [field: SerializeField] public GameObject Target { get; set; }
        [field: SerializeField] public AIState CurrentState { get; private set; }
        [field: SerializeField] public UnityEvent OnFireButtonPressed { get; set; }
        [field: SerializeField] public UnityEvent OnFireButtonReleased { get; set; }
        [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }

        private void Awake()
        {
            Target = FindObjectOfType<Player>().gameObject;
        }

        private void Update()
        {
            if(Target == null)
                OnMovementKeyPressed?.Invoke(Vector2.zero);

            else
                CurrentState.UpdateState();
        }

        public void Attack() 
        {
            OnFireButtonPressed?.Invoke();
        }

        public void Move(Vector2 moveDirection, Vector2 targetPosition)
        {
            OnMovementKeyPressed?.Invoke(moveDirection);
            OnPointerPositionChanged?.Invoke(targetPosition);
        }

        internal void ChangeToState(AIState state)
        {
            CurrentState = state;
        }
    }
}
