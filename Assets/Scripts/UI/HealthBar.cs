using Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private HealthBase healthComponent;

        private void Awake()
        {
            healthComponent.OnGetHit += OnGetHit;
            healthComponent.OnDie += OnDie;
            
            slider.maxValue = healthComponent.GetHealth();
            slider.value = healthComponent.GetHealth();
        }

        private void OnGetHit(int hitDamage)
        {
            slider.value -= hitDamage;
        }

        private void OnDie()
        {
            slider.value = 0;
        }
    }
}
