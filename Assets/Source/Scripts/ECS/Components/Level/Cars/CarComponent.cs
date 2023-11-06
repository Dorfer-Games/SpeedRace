using System.Collections.Generic;
using UnityEngine;

public class CarComponent : MonoBehaviour
{
    public float movementProgress { get; set; }
    public int index { get; set; }

    public List<BoostEffect> effects { get; } = new List<BoostEffect>();
}
