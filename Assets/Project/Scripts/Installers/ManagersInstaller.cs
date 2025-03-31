using UnityEngine;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private NavigationService navigationService;
    [SerializeField] private InventoryManager inventoryManager;

    public override void InstallBindings()
    {
        Container.BindInstance(inputManager);
        Container.BindInstance(navigationService);
        Container.BindInstance(inventoryManager);
    }
}
