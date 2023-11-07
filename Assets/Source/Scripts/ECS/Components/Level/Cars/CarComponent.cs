using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarComponent : MonoBehaviour
{
    public readonly UnityEvent Changed = new UnityEvent();

    private float _movementProgress;
    public float movementProgress
    {
        get => _movementProgress;
        set
        {
            _movementProgress = value;
            Changed?.Invoke();
        }
    }

    public int index { get; set; }
    public CarDefinition definition { get; set; }

    public List<BoostEffect> effects { get; } = new List<BoostEffect>();
}
