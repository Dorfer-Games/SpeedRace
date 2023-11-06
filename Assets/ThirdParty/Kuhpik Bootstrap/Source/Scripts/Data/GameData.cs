using AYellowpaper.SerializedCollections;
using System;
using UnityEngine;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        // Example (I use public fields for data, but u free to use properties\methods etc)
        // public float LevelProgress;
        // public Enemy[] Enemies;
        public SerializedDictionary<int, Color> Dict = new SerializedDictionary<int, Color>();
        public int test;

        public event Action<LikeData> OnUserLikedEvent;
        public event Action<GiftData> OnUserGiftedEvent;


        public void InvokeOnUserLikedEvent(LikeData likeData)
        {
            Debug.Log("Like" + likeData.data.nickname);
            OnUserLikedEvent?.Invoke(likeData);
        }
        public void InvokeOnUserGiftedEvent(GiftData giftData)
        {
            Debug.Log("Gift" + giftData.data.nickname);
            OnUserGiftedEvent?.Invoke(giftData);
        }
    }
}