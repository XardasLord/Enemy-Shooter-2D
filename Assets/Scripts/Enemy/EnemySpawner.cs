using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyAttacker[] enemyPrefabs;
        [SerializeField] private int minTimeSpawnFrequencyInSecs = 5;
        [SerializeField] private int maxTimeSpawnFrequencyInSecs = 15;

        private bool _isSpawning;

        private IEnumerator SpawnEnemy(int index, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            
            Instantiate(enemyPrefabs[index], transform.position, transform.rotation);

            _isSpawning = false;
        }

        private void Update()
        {
            if (_isSpawning)
                return;

            _isSpawning = true;
            var enemyIndex = Random.Range(0, enemyPrefabs.Length);

            StartCoroutine(SpawnEnemy(enemyIndex, Random.Range(minTimeSpawnFrequencyInSecs, maxTimeSpawnFrequencyInSecs)));
        }
    }
}
