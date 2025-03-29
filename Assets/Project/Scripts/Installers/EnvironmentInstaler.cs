using UnityEngine;
using Zenject;

public class EnvironmentInstaler : MonoInstaller
{
    [SerializeField] private Camera mainCamera;
    public override void InstallBindings()
    {
        Container.BindInstance(mainCamera).WithId("Main");
    }
}
