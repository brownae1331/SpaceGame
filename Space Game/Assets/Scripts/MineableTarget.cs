using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableTarget : MonoBehaviour
{
    public float mineTime = 5f;
    public ItemData itemdata;

    [SerializeField] PlayerInventory playerInventory;

    public void TakeDamage()
    {
        mineTime -= Time.deltaTime;

        if (mineTime <= 0.0f)
        {
            playerInventory.AddItem(itemdata);
            //inventoryController.InsertItem(itemdata);
            Destroy(gameObject);
        }
    }
}