using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public interface IKnockBack 
    {
        void KnockBack(Vector2 direction, float power, float duration);
    }
}