using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreenElement : MonoBehaviour
{
    [SerializeField] private Image _giftIcon;
    [SerializeField] private TMP_Text _points;

    public void Redraw(Sprite sprite, int points)
    {
        _giftIcon.sprite = sprite;
        _points.text = points.ToString();
    }
}