using TMPro;
using UnityEngine;

public class ResultsScreenElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _points;

    public void Redraw(string name, int points)
    {
        _name.text = name;
        _points.text = points.ToString();
    }
}