using UnityEngine;
using UnityEngine.UI;
using Variables;

namespace Player
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private IntVariable health;

        private void Awake()
        {
            slider.maxValue = health.Value;
            slider.value = health.Value;
        }

        private void Update()
        {
            slider.value = health.Value;
        }
    }
}
