using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManagement : MonoBehaviour
{
    private int previousItemSlot = 10;
    private int selectedItemSlot = 0;

    private Vector2 currentSlotLocation;
    private Vector2? previousSlotLocation;

    private int slotWidth = 96;
    private int slotHeight = 96;

    private int itemWidth = 32;
    private int itemHeight = 32;

    [SerializeField] HotbarHighlight hotbarHighlight;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform hotbarTransform;
    [SerializeField] List<ItemData> items;

    private void Start()
    {
        HighlightSlot();
        AddItemToSlot(items[0], 0);
        AddItemToSlot(items[1], 1);
        AddItemToSlot(items[2], 2);
        AddItemToSlot(items[3], 3);
        DisplaySlotItem(items[0]);
        previousItemSlot = 0;

    }

    private void Update()
    {
        HighlightSlot();
        ChangeSelectedSlot();
        DisplaySlotItem(items[selectedItemSlot]);
    }
    
    private void DisplaySlotItem(ItemData itemData)
    {
        if (selectedItemSlot != previousItemSlot)
        {
            Instantiate(itemData.itemPrefab);
        }
    }

    private void HighlightSlot()
    {
        currentSlotLocation = new Vector2 (selectedItemSlot * 32, 0);

        if (currentSlotLocation == previousSlotLocation) { return; }

        hotbarHighlight.Show(true);
        hotbarHighlight.SetSize(slotWidth, slotHeight);
        hotbarHighlight.SetPosition(currentSlotLocation);
        previousSlotLocation = currentSlotLocation;
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
        }
    
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 0;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 1;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 2;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 3;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 4;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 5;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 6;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 7;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                previousItemSlot = selectedItemSlot;
                selectedItemSlot = 8;
            }
        }
    }
}
