using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManagement : MonoBehaviour
{
    public int selectedItemSlot = -1;
    public int previousItemSlot = -1;

    private Vector2 currentSlotLocation;

    private int slotWidth = 96;
    private int slotHeight = 96;

    private int itemWidth = 64;
    private int itemHeight = 64;

    [SerializeField] PauseManager pauseManager;
    [SerializeField] HotbarHighlight hotbarHighlight;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform hotbarTransform;
    [SerializeField] List<ItemData> hotbarItems;
    [SerializeField] List<GameObject> hotbarItemIcons;

    public bool selectedItemChanged = false;
    public bool deleteInspectorItem = false;
    public int deletedItemObject;

    private void Update()
    {
        if (!pauseManager.isPaused)
        {
            HighlightSlot();
            ChangeSelectedSlot();
        }

        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                RemoveItemIcon();
            }
        }
    }
     
    private void RemoveItemIcon()
    {
        if (CheckIfMouseOnHotbar(Input.mousePosition.x, Input.mousePosition.y))
        {
            int itemSlot = CalcualteMouseOnSlot(Input.mousePosition.x, Input.mousePosition.y);
            hotbarItems[itemSlot] = null;
            Destroy(hotbarItemIcons[itemSlot]);
            hotbarItemIcons[itemSlot] = null;

            deleteInspectorItem = true;
            deletedItemObject = itemSlot;
        }
    }

    public ItemData GetSelectedItem()
    {
        if (selectedItemSlot != -1)
        {
            return hotbarItems[selectedItemSlot];
        }
        return null;
    }

    private void HighlightSlot()
    {
        if (selectedItemSlot == -1) { return; }

        currentSlotLocation = new Vector2(selectedItemSlot * 64, 0);

        hotbarHighlight.Show(true);
        hotbarHighlight.SetPosition(currentSlotLocation);
    }

    private void AddItemToSlot(ItemData itemData, int itemSlot)
    {
        GameObject newItem = Instantiate(itemPrefab);

        RectTransform itemRect = newItem.GetComponent<RectTransform>();
        itemRect.SetParent(hotbarTransform);

        newItem.GetComponent<Image>().sprite = itemData.itemIcon;

        Vector2 size = new Vector2(slotWidth, slotHeight);
        newItem.GetComponent<RectTransform>().sizeDelta = size;

        Vector2 pos = new Vector2();
        pos.x = itemSlot * itemWidth + itemWidth / 2;
        pos.y = -(itemSlot + itemHeight / 2);
        itemRect.localPosition = pos;

        hotbarItems[itemSlot] = itemData;
        hotbarItemIcons[itemSlot] = newItem;
    }

    public void DragItemToSlot(ItemData itemData)
    { 
        int slotToAdd = CalcualteMouseOnSlot(Input.mousePosition.x, Input.mousePosition.y);
        if (hotbarItems[slotToAdd] != null)
        {
            Destroy(hotbarItemIcons[slotToAdd]);
            deleteInspectorItem = true;
            deletedItemObject = slotToAdd;
        }

        AddItemToSlot(itemData, slotToAdd);
    }

    public bool CheckIfMouseOnHotbar(float posX, float posY)
    {
        Vector2 pos = new Vector2();
        pos.x = posX - hotbarTransform.position.x;
        pos.y = hotbarTransform.position.y - posY;
        if (pos.y >= 0 && pos.y <= slotHeight && pos.x >= 0 && pos.x <= slotWidth * 9)
        {
            return true; 
        }
        return false;
    }

    private int CalcualteMouseOnSlot(float posX, float posY)
    {
        Vector2 position = new Vector2();
        position.x = posX - hotbarTransform.position.x;
        position.y = hotbarTransform.position.y - posY;
        int selectedSlot = Mathf.FloorToInt(position.x / slotWidth);
        return selectedSlot;
    }

    private void ChangeSelectedSlot()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            previousItemSlot = selectedItemSlot;
            if (selectedItemSlot >= 8)
            {
                selectedItemSlot = 0;
            }

            else
            {
                selectedItemSlot++;
            }
            selectedItemChanged = true;
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            previousItemSlot = selectedItemSlot;
            if (selectedItemSlot <= 0)
            {
                selectedItemSlot = 8;
            }

            else
            {
                selectedItemSlot--;
            }
            selectedItemChanged = true;
        }
    
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 0;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 1;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 2;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 3;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 4;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 5;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 6;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 7;
                selectedItemChanged = true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 8;
                selectedItemChanged = true;
            }
        }
    }
}
