using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

namespace TopDownShooter
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] private List<ItemSpawnData> itemToDrop = new List<ItemSpawnData>();
        [SerializeField] [Range(0 ,1)] private float dropChance;

        private float[] itemWeights;

        private void Start()
        {
            itemWeights = itemToDrop.Select(item => item.dropRate).ToArray();
        }

        public void DropItem()
        {
            float dropVariable = Random.value;

            if(dropVariable < dropChance)
            {
                int index = GetRandomWeightedIndex(itemWeights);
                Instantiate(itemToDrop[index].itemPrefab, transform.position, Quaternion.identity);
            } 
        }

        private int GetRandomWeightedIndex(float[] itemWeights)
        {
            float sum = 0f;

            for (int i = 0; i < itemWeights.Length; i++)
            {
                sum += itemWeights[i];
            }

            float randomValue = Random.Range(0, sum);
            float temSum = 0f;

            for (int i = 0; i < itemToDrop.Count; i++)
            {
                if(randomValue >= temSum && randomValue < temSum + itemWeights[i])
                    return i;

                temSum += itemWeights[i];
            }

            return 0;
        }
    }

    [Serializable]
    public struct ItemSpawnData
    {
        [Range(0, 1)] public float dropRate;
        public GameObject itemPrefab;
    }
}