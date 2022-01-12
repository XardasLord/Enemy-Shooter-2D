using UnityEngine;

namespace Weapons
{
    public class WeaponEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem fireVFX;

        public void ShowFireEffect()
        {
            if (fireVFX is null)
            {
                Debug.LogError("Weapon does not have fire visual effect attached");
                return;
            }
            
            fireVFX.Play();
        }
    }
}