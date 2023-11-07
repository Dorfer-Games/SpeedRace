using Cinemachine;
using UnityEngine;
using UnityEngine.Splines;

public class LevelComponent : MonoBehaviour
{
    [field: SerializeField] public SplineContainer spline { get; private set; }

    [field: SerializeField] public CinemachineVirtualCamera startupCamera { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera mainCamera { get; private set; }

    public void ShowMainCamera()
    {
        mainCamera.enabled = true;
        startupCamera.enabled = false;
    }

    public void ShowStartupCamera()
    {
        mainCamera.enabled = false;
        startupCamera.enabled = true;
    }

    public Point GetStartPoint(CarComponent car)
    {
        return new Point(
            spline.EvaluatePosition(car.index, 0),
            Quaternion.LookRotation(spline.EvaluateTangent(car.index, 0), Vector3.up)
            );
    }

    public Point GetCarPoint(CarComponent car)
    {
        var repeatedT = Mathf.Repeat(car.movementProgress, 1);
        return new Point(
            spline.EvaluatePosition(car.index, repeatedT),
            Quaternion.LookRotation(spline.EvaluateTangent(car.index, repeatedT), Vector3.up)
            );
    }
}
