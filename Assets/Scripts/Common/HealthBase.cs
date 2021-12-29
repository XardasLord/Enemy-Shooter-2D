using System;
using UnityEngine;

namespace Common
{
    public abstract class HealthBase : MonoBehaviour
    {
        public abstract event Action OnDie;
        public abstract event Action<int> OnGetHit;

        public abstract void TakeDamage(int damage);
        public abstract int GetHealth();
    }
}