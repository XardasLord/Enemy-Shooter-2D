using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneChanger : MonoBehaviour
    {
        public void OnPlayerDie()
        {
            StartCoroutine(LoadLevelAfterDelay(3f));
        }

        private IEnumerator LoadLevelAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            SceneManager.LoadScene("GameLevel");
        }
    }
}
