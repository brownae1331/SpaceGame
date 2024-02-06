using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItemHeld : MonoBehaviour
{
    private GameObject displayedItem;

    [SerializeField] HotbarManagement hotbarManagement;

    private void ShowItem(ItemData itemData)
    {
        displayedItem = itemData.itemPrefab;
        displayedItem.SetActive(true);
    }
}
