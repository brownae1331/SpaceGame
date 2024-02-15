using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class SwitchItemHeld : MonoBehaviour
{
    private ItemData itemData;
    private GameObject itemToDisplay;

    [SerializeField] HotbarManagement hotbarManagement;
    [SerializeField] new Camera camera;
    [SerializeField] Transform weaponHolderTransform;
    [SerializeField] GameObject impactEffect;
    [SerializeField] Animator animator;

    private void Start()
    {
        itemData = hotbarManagement.GetSelectedIten();
        DisplaySlotItem();
    }

    private void Update()
    {
        if (hotbarManagement.SelectedItemChanged())
        {
            Destroy(itemToDisplay);
            itemData = hotbarManagement.GetSelectedIten();
            DisplaySlotItem();
        }
    }

    private void DisplaySlotItem()
    {
        itemToDisplay = Instantiate(itemData.itemPrefab);

        Transform itemTransform = itemToDisplay.GetComponent<Transform>();
        itemTransform.SetParent(weaponHolderTransform);

        itemTransform.localPosition = itemData.itemPos;

        Quaternion itemRotation = Quaternion.Euler(itemData.itemRotation);
        itemTransform.localRotation = itemRotation;

        // Add references to prefab
        if (itemData.itemType == "MiningGun")
        {
            LazerGun lazerGunScript = itemToDisplay.GetComponent<LazerGun>();
            lazerGunScript.fpsCam = camera;
        }

        else if (itemData.itemType == "Gun")
        {
            Gun gunScrpit = itemToDisplay.GetComponent<Gun>(); 
            gunScrpit.fpsCam = camera;
            gunScrpit.impactEffect = impactEffect;
            if (animator != null)
            {
                gunScrpit.animator = animator;
            }
        }
    }
}
