using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private EnemyHealth healthComponent;

        private void Awake()
        {
            slider.maxValue = healthComponent.GetHealth();
            slider.value = healthComponent.GetHealth();
        }

        private void Update()
        {
            slider.value = healthComponent.GetHealth();
        }
    }
}
