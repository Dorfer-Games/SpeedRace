using Kuhpik;
using System.Linq;
using UnityTools.Extentions;

public class CarSelectionSystem : GameSystem
{
    private BoostSystem _boostSystem;

    public override void OnStateEnter()
    {
        game.ttEvents.Commented += OnCommented;
    }

    public override void OnStateExit()
    {
        game.ttEvents.Commented -= OnCommented;
    }

    public override void OnUpdate()
    {
        TryStart();
    }

    private void OnCommented(CommentData comment)
    {
        if (!int.TryParse(comment.data.comment, out var index)) return;
        if (!_boostSystem.ValidateIndex(index)) return;
        if (game.cars.Any(x => x.index == index)) return;
        SpawnCar(index);
    }

    private void SpawnCar(int index)
    {
        var instance = Instantiate(config.carPrefab, game.level.transform);
        instance.index = index;
        var point = game.level.GetStartPoint(instance);
        instance.transform.ApplyPoint(point);
        game.cars.Add(instance);
    }

    private void TryStart()
    {
        if (game.cars.Count >= 8)
        {
            ChangeGameState(GameStateID.Race);
        }
    }
}

