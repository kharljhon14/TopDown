using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TopDownShooter
{
    public class UIAmmo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ammoText = null;

        public void UpdateBulletText(int bulletCount)
        {
            if (bulletCount == 0)
                ammoText.color = Color.red;

            else
                ammoText.color = Color.white;

            ammoText.SetText(bulletCount.ToString());
        }
    }
}