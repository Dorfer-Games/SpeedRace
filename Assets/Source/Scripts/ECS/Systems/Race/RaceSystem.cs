using Kuhpik;
using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class RaceSystem : GameSystemWithScreen<ScoreScreen>
{
    public override void OnUpdate()
    {
        MoveCars();
    }

    public override void OnStateEnter()
    {
        screen.Init(game.cars, game.level.splineLength);
    }

    public override void OnStateExit()
    {
        screen.Dispose();
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
        if (game.cars.Any(x => x.movementProgress >= config.targetPointsAmmount))
        {
            ChangeGameState(GameStateID.Results);
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

