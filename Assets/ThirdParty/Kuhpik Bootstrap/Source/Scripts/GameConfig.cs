using System.Collections.Generic;
using UnityEngine;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public List<CarComponent> carPrefabs { get; private set; }
        [field: SerializeField] public float baseCarSpeed { get; private set; }
        [field: SerializeField] public List<GiftInfo> gifts { get; private set; }
        [field: SerializeField] public float targetPointsAmmount { get; private set; }
        [field: SerializeField] public float resultDuration { get; private set; }

        public int carCount => carPrefabs.Count;
    }
}