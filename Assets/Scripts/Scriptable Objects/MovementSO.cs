using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName ="Player/MovementData")]
    public class MovementSO : ScriptableObject
    {
        [Range(1, 10)] public float maxSpeed = 5f;
        [Range(.1f, 100f)] public float accelaration = 100f;
        [Range(.1f, 100f)] public float deaccelaration = 100f;
    }
}
