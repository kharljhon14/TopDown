using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class Resouce : MonoBehaviour
    {
        [field: SerializeField] public ResourceSO resouceType { get; set; }

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PickupResouce()
        {
            StartCoroutine(DestroyCoroutine());
        }

        public IEnumerator DestroyCoroutine()
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            Destroy(gameObject);
        }
    }
}
