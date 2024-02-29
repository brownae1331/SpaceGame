using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SwitchItemHeld : MonoBehaviour
{
    private ItemData itemData;
    private GameObject itemToDisplay;
    [SerializeField] List<GameObject> itemsInInspector;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] HotbarManagement hotbarManagement;
    [SerializeField] new Camera camera;
    [SerializeField] Transform weaponHolderTransform;
    [SerializeField] GameObject impactEffect;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI ammoText;

    private void Start()
    {
        itemData = hotbarManagement.GetSelectedItem();
        DisplaySlotItem();
    }

    private void Update()
    {
        if (hotbarManagement.selectedItemChanged)
        {
            if (hotbarManagement.previousItemSlot != -1 && itemsInInspector[hotbarManagement.previousItemSlot] != null)
            {
                itemsInInspector[hotbarManagement.previousItemSlot].SetActive(false);
                ammoText.gameObject.SetActive(false);

            }       
            
            itemData = hotbarManagement.GetSelectedItem();
            DisplaySlotItem();

            hotbarManagement.selectedItemChanged = false;
        }

        if (hotbarManagement.deleteInspectorItem && hotbarManagement.deletedItemObject != -1)
        {
            Destroy(itemsInInspector[hotbarManagement.deletedItemObject]);
            hotbarManagement.deleteInspectorItem = false;
            hotbarManagement.deletedItemObject = -1;
        }
    }

    private void DisplaySlotItem()
    {
        if (itemData == null) { return; }

        if (itemsInInspector[hotbarManagement.selectedItemSlot] != null)
        {
            itemsInInspector[hotbarManagement.selectedItemSlot].SetActive(true);

            if (itemData.itemType == "Gun")
            {
                ammoText.gameObject.SetActive(true);
                Gun gunScript = itemsInInspector[hotbarManagement.selectedItemSlot].GetComponent<Gun>();
                gunScript.UpdateAmmoText();
            }
        }

        else
        {
            itemToDisplay = Instantiate(itemData.itemPrefab);

            Transform itemTransform = itemToDisplay.GetComponent<Transform>();
            itemTransform.SetParent(weaponHolderTransform);

            itemTransform.localPosition = itemData.itemPos;

            Quaternion itemRotation = Quaternion.Euler(itemData.itemRotation);
            itemTransform.localRotation = itemRotation;

            itemsInInspector[hotbarManagement.selectedItemSlot] = itemToDisplay;

            // Add references to prefab
            if (itemData.itemType == "MiningGun")
            {
                LazerGun lazerGunScript = itemToDisplay.GetComponent<LazerGun>();
                lazerGunScript.fpsCam = camera;
                lazerGunScript.pauseManager = pauseManager;
            }

            else if (itemData.itemType == "Gun")
            {
                Gun gunScrpit = itemToDisplay.GetComponent<Gun>();
                gunScrpit.fpsCam = camera;
                gunScrpit.impactEffect = impactEffect;
                gunScrpit.animator = animator;
                gunScrpit.SetAnimator();
                gunScrpit.pauseManager = pauseManager;
                gunScrpit.ammoText = ammoText;
                gunScrpit.UpdateAmmoText();
                ammoText.gameObject.SetActive(true);
            }
        }

    }
}
