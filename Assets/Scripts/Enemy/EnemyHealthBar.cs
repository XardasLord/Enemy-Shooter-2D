using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private IntVariableInstancer health;

        private void Start()
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
