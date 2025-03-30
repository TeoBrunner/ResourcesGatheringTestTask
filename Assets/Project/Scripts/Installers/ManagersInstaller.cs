using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private NavigationService navigationService;

    public override void InstallBindings()
    {
        Container.BindInstance(inputManager);
        Container.BindInstance(navigationService);
    }
}
