using Kuhpik;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreScreen : UIScreen
{
    [SerializeField] private List<ScoreScreenElement> _elements;

    public void Init(List<CarComponent> cars, float raceDistance)
    {
        var sorted = cars.OrderBy(x => x.index).ToList();
        for (int i = 0; i < sorted.Count; i++)
        {
            _elements[i].Init(sorted[i], raceDistance);
        }
    }

    public void Dispose()
    {
        foreach (var element in _elements)
        {
            element.Dispose();
        }
    }
}
