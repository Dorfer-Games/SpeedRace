using UnityEngine;
using UnityEngine.Splines;

public class LevelComponent : MonoBehaviour
{
    [field: SerializeField] public SplineContainer spline { get; private set; }
}
