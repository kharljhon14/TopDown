using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public interface IAgentInput
    {
        UnityEvent OnFireButtonPressed { get; set; }
        UnityEvent OnFireButtonReleased { get; set; }
        UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        UnityEvent<Vector2> OnPointerPositionChanged { get; set; }
    }
}