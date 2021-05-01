using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Enemies/EnemyData")]
    public class EnemySO : ScriptableObject
    {
        [field: SerializeField] public int MaxHealth { get; set; } = 3;
        [field: SerializeField] public int Damage { get; set; } = 1;
    }
}
