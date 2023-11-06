using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kuhpik
{
    [Serializable]
    public class GameData
    {
        public event Action<LikeData> OnUserLikedEvent;
        public event Action<GiftData> OnUserGiftedEvent;

        public LevelComponent level;

        public List<CarComponent> cars = new List<CarComponent>();

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