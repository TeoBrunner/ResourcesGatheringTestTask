using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;

    public override void InstallBindings()
    {
        Container.BindInstance(inputManager);
    }
}
