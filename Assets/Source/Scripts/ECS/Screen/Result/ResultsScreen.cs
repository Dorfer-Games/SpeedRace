using Kuhpik;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityTools.Extentions;

public class ResultsScreen : UIScreen
{
    [SerializeField] private List<ResultsScreenElement> _elements;

    public void Init(List<CarComponent> cars, float raceLenght)
    {
        cars
            .OrderByDescending(x => x.movementProgress)
            .ForEach((x, i) => _elements[i].Redraw((x.index + 1).ToString(), (int)(x.movementProgress * raceLenght)));
    }
}
