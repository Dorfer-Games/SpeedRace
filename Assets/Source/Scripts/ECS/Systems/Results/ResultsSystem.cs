using Kuhpik;
using UnityTools.Extentions;

public class ResultsSystem : GameSystemWithScreen<ResultsScreen>
{
    public override void OnStateEnter()
    {
        screen.Init(game.cars, game.level.splineLenght);
        game.level.ShowStartupCamera();
        this.Invoke(() => ChangeGameState(GameStateID.Loading), config.resultDuration);
    }
}
