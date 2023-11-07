using Kuhpik;
using System.Linq;
using UnityTools.Extentions;

public class CarSelectionSystem : GameSystem
{
    public override void OnStateEnter()
    {
        game.level.ShowStartupCamera();
        game.ttEvents.Commented += OnCommented;
    }

    public override void OnStateExit()
    {
        game.level.ShowMainCamera();
        game.ttEvents.Commented -= OnCommented;
    }

    public override void OnUpdate()
    {
        TryStart();
        game.ttEvents.TryRaiseEvents();
    }

    private void OnCommented(CommentData comment)
    {
        if (!int.TryParse(comment.data.comment, out var carNumber)) return;
        if (carNumber < 1 || carNumber > config.carCount) return;
        if (game.cars.Any(x => x.index == carNumber - 1)) return;
        SpawnCar(carNumber - 1);
    }

    private void SpawnCar(int index)
    {
        var instance = Instantiate(config.cars[index].prefab, game.level.transform);
        instance.index = index;
        var point = game.level.GetStartPoint(instance);
        instance.transform.ApplyPoint(point);
        game.cars.Add(instance);
    }

    private void TryStart()
    {
        if (game.cars.Count >= config.carCount)
        {
            ChangeGameState(GameStateID.Race);
        }
    }
}

