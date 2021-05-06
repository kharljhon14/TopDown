using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefab;
        [SerializeField] private List<GameObject> spawnPoints;
        [SerializeField] private int enemyCount = 20;
        [SerializeField] private float minTimeDelay = .8f;
        [SerializeField] private float maxTimeDelay = 1.5f;

        private void Start()
        {
            if(spawnPoints.Count > 0)
            {
                foreach (GameObject spawnPoint in spawnPoints)
                {
                    SpawnEnemy(spawnPoint.transform.position);
                }
            }

            StartCoroutine(SpawnCoroutine());
               
        }

        private IEnumerator SpawnCoroutine()
        {
            while(enemyCount > 0)
            {
                enemyCount--;

                int randomIndex = Random.Range(0, spawnPoints.Count);
                Vector2 randomOffset = Random.insideUnitCircle;
                Vector3 spawnPoint = spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;

                SpawnEnemy(spawnPoint);

                float randomTime = Random.Range(minTimeDelay, maxTimeDelay);

                yield return new WaitForSeconds(randomTime);
            }
        }

        private void SpawnEnemy(Vector3 spawnPoint)
        {
            int randomIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomIndex], spawnPoint, Quaternion.identity);
        }
    }
}
