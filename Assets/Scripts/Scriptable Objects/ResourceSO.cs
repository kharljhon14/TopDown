using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Items/ResouceData")]
    public class ResourceSO : ScriptableObject
    {
        [field: SerializeField] public ResouceType ResouceEnum { get; set; }

        [SerializeField] private int minAmount = 1;
        [SerializeField] private int maxAmount = 5;

        public int GetAmount()
        {
            return Random.Range(minAmount, maxAmount + 1);
        }
    }

    public enum ResouceType 
    { 
        None,
        Health,
        Ammo
    }
}
