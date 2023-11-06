using Kuhpik;
using UnityTools.Extentions;

public class CarSelectionSystem : GameSystem
{
    public override void OnStateEnter()
    {
        var instance = Instantiate(config.carPrefab, game.level.transform);
        instance.index = 0;
        var point = game.level.GetStartPoint(instance);
        instance.transform.ApplyPoint(point);
        game.cars.Add(instance);

        ChangeGameState(GameStateID.Race);
    }
}

