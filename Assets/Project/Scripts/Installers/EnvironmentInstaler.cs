using UnityEngine;
using Zenject;

public class EnvironmentInstaler : MonoInstaller
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Popup inventoryPopup;
    public override void InstallBindings()
    {
        Container.BindInstance(mainCamera).WithId("Main");
        Container.BindInstance(inventoryPopup).WithId("InventoryPopup");
    }
}
