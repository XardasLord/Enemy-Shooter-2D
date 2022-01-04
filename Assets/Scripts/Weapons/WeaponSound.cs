using UnityEngine;

namespace Weapons
{
    public class WeaponSound : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] fireAudioClips;
        
        public void PlayFireAudio()
        {
            if (fireAudioClips is null || fireAudioClips.Length == 0)
            {
                Debug.LogWarning("No fire audio clips attached to this weapon");
                return;
            }

            audioSource.clip = fireAudioClips[Random.Range(0, fireAudioClips.Length)];
            audioSource.Play();
        }
    }
}