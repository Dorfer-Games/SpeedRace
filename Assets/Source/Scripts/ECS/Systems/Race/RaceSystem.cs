using Kuhpik;
using UnityEngine;
using UnityTools.Extentions;

public class RaceSystem : GameSystem
{
    public override void OnUpdate()
    {
        MoveCars();
    }

    private void MoveCars()
    {
        foreach (var car in game.cars)
        {
            var speed = GetCarSpeed(car) * Time.deltaTime;
            car.movementProgress += speed;
            var point = game.level.GetCarPoint(car);
            car.transform.ApplyPoint(point);
        }
    }

    private float GetCarSpeed(CarComponent car)
    {
        var result = config.baseCarSpeed;
        for (int i = 0; i < car.effects.Count; i++)
        {
            var effect = car.effects[i];
            result += effect.speedBoost;
        }
        return result;
    }
}

