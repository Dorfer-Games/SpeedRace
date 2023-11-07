using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreenElement : MonoBehaviour
{
    [SerializeField] private Image _giftIcon;

    [SerializeField] private TMP_Text _index;
    [SerializeField] private TMP_Text _points;

    private CarComponent _car;
    private float _raceDistance;

    public void Init(CarComponent car, float raceDistance)
    {
        _car = car;
        _raceDistance = raceDistance;
        _car.Changed.AddListener(Redraw);
        Redraw();
    }

    public void Dispose()
    {
        _car.Changed.RemoveListener(Redraw);
        _car = null;
    }

    private void Redraw()
    {
        _giftIcon.sprite = _car.definition.gift.sprite;
        _index.text = (_car.index + 1).ToString();
        _index.color = _car.definition.color;
        _points.text = ((int)(_car.movementProgress * _raceDistance)).ToString();
    }
}