using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] ItemGrid itemGrid;
    [SerializeField] InventoryController inventoryController;

    private void Start()
    {
        itemGrid.Init();
    }

    public void AddItem(ItemData item)
    {
        Vector2Int? positionToPlace = itemGrid.FindSpaceForObject(item);

        if (positionToPlace == null) { return; }

        InventoryItem newItem = inventoryController.CreateNewInventoryItem(item);
        itemGrid.PlaceItem(newItem, positionToPlace.Value.x, positionToPlace.Value.y);
    }
}
