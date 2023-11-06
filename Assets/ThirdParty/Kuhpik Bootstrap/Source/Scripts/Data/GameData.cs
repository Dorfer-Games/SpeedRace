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
        public event Action<CommentData> OnCommentEvent;

        public LevelComponent level;

        public List<CarComponent> cars = new List<CarComponent>();

        public void InvokeOnUserLikedEvent(LikeData likeData)
        {
            Debug.Log("<color=black>Like: </color>" + likeData.data.nickname);
            OnUserLikedEvent?.Invoke(likeData);
        }
        public void InvokeOnUserGiftedEvent(GiftData giftData)
        {
            Debug.Log("<color=green>Gift: </color>" + giftData.data.nickname);
            OnUserGiftedEvent?.Invoke(giftData);
        }
        public void InvokeOnCommentEvent(CommentData commentData)
        {
            Debug.Log("<color=blue>Comment: </color>" + commentData.data.comment);
            OnCommentEvent?.Invoke(commentData);
        }
    }
}