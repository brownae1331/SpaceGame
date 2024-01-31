using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot
{
    None,
    Armor,
    Helmet,
    Boots
}

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public EquipmentSlot equipmentSlot;
    public int width = 1;
    public int height = 1;

    public Sprite itemIcon;
}
