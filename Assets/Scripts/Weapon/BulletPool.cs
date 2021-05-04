using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{

    public class BulletPool : MonoBehaviour
    {
        [SerializeField] protected GameObject bulletShellPrefab;
        [SerializeField] protected int poolSize;
        protected int currentSize;
        protected Queue<GameObject> bulletPool;

        private void Awake()
        {
            bulletPool = new Queue<GameObject>();
        }

        public virtual GameObject SpawnBullet(GameObject currentObject = null)
        {
            if(currentObject == null)
                currentObject = bulletShellPrefab;

            GameObject spawnedObject = null;

            if(currentSize < poolSize)
            {
                spawnedObject = Instantiate(currentObject, transform.position, Quaternion.identity);
                spawnedObject.name = currentObject.name + "_" + currentSize;
                currentSize++;
            }

            else
            {
                spawnedObject = bulletPool.Dequeue();
                spawnedObject.transform.position = transform.position;
                spawnedObject.transform.rotation = Quaternion.identity;
            }

            bulletPool.Enqueue(spawnedObject);

            return spawnedObject;
        }
    }
}
