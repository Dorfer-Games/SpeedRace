using Kuhpik;
using System.Linq;
using UnityEngine;

public class BoostSystem : GameSystem
{
    private BoostSystemConfig _config;

    public override void OnStateEnter()
    {
        game.ttEvents.Commented += OnCommend;
        game.ttEvents.Gifted += OnGift;
    }

    public override void OnStateExit()
    {
        game.ttEvents.Commented -= OnCommend;
        game.ttEvents.Gifted -= OnGift;
    }

    public override void OnUpdate()
    {
        UpdateEffects();
        game.ttEvents.TryRaiseEvents();
    }

    private void OnGift(GiftData gift)
    {
        var giftInfo = config.gifts.FirstOrDefault(x => x.giftID == gift.data.gift.gift_id);
        if (giftInfo != null)
        {
            OnGift(giftInfo.carIndex);
        }
    }

    private void OnGift(int index)
    {
        var car = game.cars.FirstOrDefault(x => x.index == index);
        ApplyBoost(car, _config.giftBoostSpeed, _config.giftBoostDuration);
    }

    private void OnCommend(CommentData comment)
    {
        if (int.TryParse(comment.data.comment, out var index) && ValidateIndex(index))
        {
            OnCommend(index);
        }
    }

    private void OnCommend(int index)
    {
        var car = game.cars.FirstOrDefault(x => x.index == index);
        ApplyBoost(car, _config.commentBoostSpeed, _config.commentBoostDuration);
    }

    public bool ValidateIndex(int index)
    {
        return index > 0 && index < game.cars.Count;
    }

    public void ApplyBoost(CarComponent car, float speedBoost, float duration)
    {
        car.effects.Add(new BoostEffect(speedBoost, duration));
    }

    private void UpdateEffects()
    {
        foreach (var car in game.cars)
        {
            foreach (var effect in car.effects)
            {
                effect.Update(Time.deltaTime);
            }
            car.effects.RemoveAll(x => x.expired);
        }
    }
}

