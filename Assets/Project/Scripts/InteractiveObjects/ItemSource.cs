using UnityEngine;
using Zenject;

public class ItemSource : MonoBehaviour, IInteractable
{
    [SerializeField] ItemType itemType;
    [SerializeField] int itemAmountPerInteract = 1;
    
    private InventoryManager inventoryManager;



    [Inject]
    private void Construct(InventoryManager inventoryManager)
    {
        this.inventoryManager = inventoryManager;
    }
    public void Interact()
    {
        inventoryManager.AddItem(itemType,itemAmountPerInteract);
    }

}
