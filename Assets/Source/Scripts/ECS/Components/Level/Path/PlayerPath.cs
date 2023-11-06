using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Color = UnityEngine.Color;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerPath : MonoBehaviour
{
    [SerializeField, ReadOnly] private List<PlayerPathPoint> _points;

    public PlayerPathPoint this[int index] => _points[index];

    public IEnumerable<PlayerPathPoint> points => _points;

#if UNITY_EDITOR
    [Button]
    public void AddPoint()
    {
        var point = new GameObject("point").AddComponent<PlayerPathPoint>();
        point.transform.parent = transform;
        if (_points.Count > 0) point.transform.position = _points.Last().transform.position;
        _points.Add(point);
        SetPointsNames();

        Selection.activeObject = point;
    }

    public void RemovePoint(PlayerPathPoint point)
    {
        RemovePointAsync(point);
    }

    private async Task RemovePointAsync(PlayerPathPoint point)
    {
        await Task.Delay(250);
        var index = _points.IndexOf(point);
        if (_points.Count > 1)
        {
            Selection.activeObject = _points[index - 1];
        }
        else
        {
            Selection.activeObject = this;
        }
        _points.Remove(point);
        DestroyImmediate(point.gameObject);
        SetPointsNames();
    }

    [Button]
    private void ClearPath()
    {
        foreach (var point in _points)
        {
            DestroyImmediate(point.gameObject);
        }
        _points.Clear();
    }

    private void SetPointsNames()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _points[i].name = i.ToString();
        }
    }

    private void OnDrawGizmos()
    {
        if (_points == null || _points.Count < 2) return;
        var points = _points.Where(x => x != null);
        for (int i = 0; i < points.Count() - 1; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(points.ElementAt(i).position, points.ElementAt(i + 1).position);
        }
    }
#endif
}