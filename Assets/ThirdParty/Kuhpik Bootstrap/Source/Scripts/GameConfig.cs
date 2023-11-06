using UnityEngine;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField] public CarComponent carPrefab { get; private set; }
        [field: SerializeField] public float baseCarSpeed { get; private set; }
    }
}