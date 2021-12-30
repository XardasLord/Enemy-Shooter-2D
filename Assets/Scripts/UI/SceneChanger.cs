using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneChanger : MonoBehaviour
    {
        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            _playerHealth.OnDie += PlayerOnDie;
        }

        private void PlayerOnDie()
        {
            StartCoroutine(LoadLevelAfterDelay(3f));
        }

        private IEnumerator LoadLevelAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            SceneManager.LoadScene("GameLevel");
        }

        private void OnDestroy()
        {
            _playerHealth.OnDie -= PlayerOnDie;
        }
    }
}
