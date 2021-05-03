using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Impact : MonoBehaviour
    {
        public void DestroyAfterAnimation()
        {
            Destroy(gameObject);
        }
    }
}
