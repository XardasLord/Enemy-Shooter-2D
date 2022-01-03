using UnityEngine;

namespace Variables
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
        [field: SerializeField] 
        public int Value { get; set; }
    }
}