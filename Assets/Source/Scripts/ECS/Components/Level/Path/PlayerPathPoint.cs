using NaughtyAttributes;
using UnityEngine;

public class PlayerPathPoint : MonoBehaviour
{
    public Vector3 position => transform.position;

#if UNITY_EDITOR
    [ContextMenu(nameof(Snap))]
    private void Snap()
    {
        var pScene = gameObject.scene.GetPhysicsScene();
        if (pScene.Raycast(transform.position + Vector3.up, Vector3.down, out var hit))
        {
            transform.position = hit.point;
        }
    }

    [Button]
    private void AddPoint()
    {
        GetComponentInParent<PlayerPath>().AddPoint();
    }

    [Button]
    private void RemovePoint()
    {
        GetComponentInParent<PlayerPath>().RemovePoint(this);
    }
#endif
}
