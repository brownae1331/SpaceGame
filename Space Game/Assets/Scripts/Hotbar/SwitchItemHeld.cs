using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class SwitchItemHeld : MonoBehaviour
{
    private ItemData itemToDisplay;

    [SerializeField] HotbarManagement hotbarManagement;
    [SerializeField] Camera camera;
    [SerializeField] Transform weaponHolderTransform;

    private void Start()
    {
        itemToDisplay = hotbarManagement.getSelectedIten();
        DisplaySlotItem(itemToDisplay);
    }

    private void DisplaySlotItem(ItemData itemData)
    {
        GameObject itemToDisplay = Instantiate(itemData.itemPrefab);

        Transform itemTransform = itemToDisplay.GetComponent<Transform>();
        itemTransform.SetParent(weaponHolderTransform);

        itemTransform.localPosition = itemData.itemPos;

        // Add camera to prefab
        LazerGun lazerGunScript = itemToDisplay.GetComponent<LazerGun>();
        lazerGunScript.fpsCam = camera;
    }
}
