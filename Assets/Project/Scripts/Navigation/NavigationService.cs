using System;
using UnityEngine;

public class NavigationService : MonoBehaviour
{    public Vector3 TargetPosition { get; private set; }
    public event Action<Vector3> DestinationChanged;

    public void SetDestination(Vector3 position)
    {
        TargetPosition = position;
        DestinationChanged?.Invoke(TargetPosition);
    }
}
