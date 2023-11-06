using Kuhpik;
using UnityEngine;
using Random = System.Random;

public class LoadingSystem : GameSystem
{
    private LevelLoadingConfig _config;

    public override void OnStateEnter()
    {
        LoadLevel(GetLevelID(save.levelID));
    }

    private void LoadLevel(int id)
    {
        if (game.level != null)
        {
            Destroy(game.level.gameObject);
        }
        game.cars.Clear();

        var path = $"{_config.path}/{id}";
        var prefab = Resources.Load<LevelComponent>(path);
        game.level = Instantiate(prefab);
        ChangeGameState(GameStateID.CarSelection);
    }

    private int GetLevelID(int levelID)
    {
        var levelCount = Resources.LoadAll<LevelComponent>(_config.path).Length;
        if (levelID < levelCount)
        {
            return levelID;
        }
        else
        {
            return new Random(levelID).Next(0, levelCount - 1);
        }
    }
}

