using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private EnemyHealth healthComponent;

        private void Start()
        {
            slider.maxValue = healthComponent.Health;
            slider.value = healthComponent.Health;
        }

        private void Update()
        {
            slider.value = healthComponent.Health;
        }
    }
}
