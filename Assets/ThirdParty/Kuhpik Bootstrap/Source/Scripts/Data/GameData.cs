using System;
using UnityEngine;

namespace Kuhpik
{
    [Serializable]
    public class GameData
    {
        public event Action<LikeData> OnUserLikedEvent;
        public event Action<GiftData> OnUserGiftedEvent;

        public LevelComponent level;

        public void InvokeOnUserLikedEvent(LikeData likeData)
        {
            Debug.Log($"Like {likeData.data.nickname}");
            OnUserLikedEvent?.Invoke(likeData);
        }

        public void InvokeOnUserGiftedEvent(GiftData giftData)
        {
            Debug.Log($"Gift {giftData.data.nickname}");
            OnUserGiftedEvent?.Invoke(giftData);
        }
    }
}