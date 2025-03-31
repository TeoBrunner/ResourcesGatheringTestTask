using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class PopupManager : MonoBehaviour
{
    private Popup inventoryPopup;

    private InventoryManager inventoryManager;

    [Inject]
    private void Construct([Inject] InventoryManager inventoryManager,
                           [Inject(Id = "InventoryPopup")] Popup inventoryPopupObject)
    {
        this.inventoryManager = inventoryManager;
        this.inventoryPopup = inventoryPopupObject;
    }

    private void OnEnable()
    {
        inventoryManager.inventoryChanged += ShowInventoryPopup;
    }
    private void OnDisable()
    {
        inventoryManager.inventoryChanged -= ShowInventoryPopup;
    }

    private void ShowInventoryPopup()
    {
        string content = "";
        foreach (var key in inventoryManager.inventory.Keys)
        {
            content += $"{key}: {inventoryManager.inventory[key]}\n";
        }

        inventoryPopup.UpdateContent(content);

        inventoryPopup.Show();
    }


}
