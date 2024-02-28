using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public int width = 1;
    public int height = 1;

    public Sprite itemIcon;
    public GameObject itemPrefab;

    public Vector3 itemPos;
    public Vector3 itemRotation;

    public string itemType;

    public int stackLimit;
}
