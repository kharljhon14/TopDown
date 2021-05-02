using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public interface IAgent
    {
        int Health { get; }
        UnityEvent OnDeath { get; set; }
        UnityEvent OnGetHit { get; set; }
    }
}