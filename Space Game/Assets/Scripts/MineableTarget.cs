using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableTarget : MonoBehaviour
{
    public float mineTime = 5f;
    public ItemData itemdata;
    
    public InventoryController inventoryController;

    public void TakeDamage()
    {
        mineTime -= Time.deltaTime;

        if (mineTime <= 0.0f)
        {
            inventoryController.InsertItem(itemdata);
            Destroy(gameObject);
        }
    }
}
