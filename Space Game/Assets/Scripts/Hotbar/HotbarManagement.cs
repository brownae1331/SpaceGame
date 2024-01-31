using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HotbarManagement : MonoBehaviour
{
    private int selectedItemSlot = 0;
    public Vector2 currentSlotLocation;

    [SerializeField] HotbarHighlight hotbarHighlight;

    private void Update()
    {
        HighlightSlot();
    }

    private void HighlightSlot()

    {
        currentSlotLocation = new Vector2 (0, 0);

        hotbarHighlight.Show(true);
        hotbarHighlight.SetSize(96, 96);
        hotbarHighlight.SetPosition(currentSlotLocation);
    }
}
