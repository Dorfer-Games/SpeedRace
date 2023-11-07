using Kuhpik;
using UnityEngine;
using UnityTools.Extentions;

public class FakeEventSource : GameSystem
{
    [SerializeField] private bool _isActive;

    [SerializeField, Range(0, 1f)] private float _incorrectCommentChance;
    [SerializeField, Range(0, 1f)] private float _incorrectGiftChance;

    public void Update()
    {
        if (!_isActive) return;
        if (Input.GetKeyDown(KeyCode.C))
        {
            InvokeFakeComment();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            InvokeFakeGift();
        }
    }

    private void InvokeFakeGift()
    {
        var gift = GenerateObject<GiftData>();
        if (Random.Range(0, 1f) < _incorrectGiftChance)
        {
            gift.data.gift.gift_id = config.gifts.GetRandom().giftID;
        }
        else
        {
            gift.data.gift.gift_id = Random.Range(0, int.MaxValue);
        }
        gift.data.nickname = gift.data.gift.gift_id.ToString();
        game.ttEvents.AddGiftEvent(gift);

    }

    private void InvokeFakeComment()
    {
        var comment = GenerateObject<CommentData>();
        if (Random.Range(0, 1f) < _incorrectCommentChance)
        {
            comment.data.comment = Random.Range(1, config.carCount + 1).ToString();
        }
        else
        {
            comment.data.comment = "NOTHING";
        }
        game.ttEvents.AddCommentEvent(comment);
    }

    private T GenerateObject<T>() where T : class, new()
    {
        return JsonUtility.FromJson<T>(JsonUtility.ToJson(new T()));
    }
}

