using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/CarDefinition")]
public sealed class CarDefinition : ScriptableObject
{
    [field: SerializeField, ShowAssetPreview] public CarComponent prefab { get; private set; }
    [field: SerializeField] public Color color { get; private set; }
    [field: SerializeField] public string displayName { get; private set; }
    [field: SerializeField] public GiftDefinition gift { get; private set; }

    [field: SerializeField] public Sprite leaderSprite { get; private set; }
    [field: SerializeField] public Sprite memeberSprite { get; private set; }
}
