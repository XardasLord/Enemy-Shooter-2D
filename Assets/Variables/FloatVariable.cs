using UnityEngine;

namespace Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
        [field: SerializeField] 
        public float Value { get; set; }
    }
}
