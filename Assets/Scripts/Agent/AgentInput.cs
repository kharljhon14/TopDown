using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class AgentInput : MonoBehaviour, IAgentInput
    {
        private Camera mainCamera;
        private bool fireButtonDown = false;

        [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }
        [field: SerializeField] public UnityEvent OnFireButtonPressed { get; set; }
        [field: SerializeField] public UnityEvent OnFireButtonReleased { get; set; }

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            GetMovementInput();
            GetPointerInput();
            GetFireInput();
        }

        private void GetFireInput()
        {
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                if (!fireButtonDown)
                {
                    fireButtonDown = true;
                    OnFireButtonPressed?.Invoke();
                }
            }

            else
            {
                if (fireButtonDown)
                {
                    fireButtonDown = false;
                    OnFireButtonReleased?.Invoke();
                }
            }
        }

        private void GetPointerInput()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.nearClipPlane;

            Vector3 mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition);
            OnPointerPositionChanged?.Invoke(mouseInWorldSpace);
        }

        private void GetMovementInput()
        {
            OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}