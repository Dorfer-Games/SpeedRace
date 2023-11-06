using Kuhpik;
using System.Linq;
using UnityEngine;

public class BoostSystem : GameSystem
{
    private BoostSystemConfig _config;

    public override void OnUpdate()
    {
        UpdateEffects();
    }

    private void OnGift(int index)
    {
        var car = game.cars.FirstOrDefault(x => x.index == index);
        ApplyBoost(car, _config.giftBoostSpeed, _config.giftBoostDuration);
    }

    private void OnCommend(int index)
    {
        var car = game.cars.FirstOrDefault(x => x.index == index);
        ApplyBoost(car, _config.commentBoostSpeed, _config.commentBoostDuration);
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

