using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPowerUpPrefabs;

    [Space(3)]
    [SerializeField] private float waitingForNextSpawnInSecs = 10;
    
    [Header("X Spawn Range")]
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;

    [Header("Y Spawn Range")]
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    
    private float _nextTimeSpawn = 10;
  
    public void Update()
    {
        _nextTimeSpawn -= Time.deltaTime;
        
        if(_nextTimeSpawn <= 0)
        {
            SpawnItem();
            _nextTimeSpawn = waitingForNextSpawnInSecs;
        }
    }
    
    private void SpawnItem()
    {
        var positionToSpawn = new Vector2 (Random.Range(xMin, xMax), Random.Range(yMin, yMax));
  
        var itemPrefab = itemPowerUpPrefabs[Random.Range (0, itemPowerUpPrefabs.Length)];
 
        Instantiate(itemPrefab, positionToSpawn, Quaternion.identity);
    }
}
