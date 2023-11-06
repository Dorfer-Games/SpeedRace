using System.Collections.Generic;
using UnityEngine;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public CarComponent carPrefab { get; private set; }
        [field: SerializeField] public float baseCarSpeed { get; private set; }
        [field: SerializeField] public List<GiftInfo> gifts { get; private set; }
    }
}