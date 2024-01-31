using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HotbarHighlight : MonoBehaviour
{
    [SerializeField] RectTransform highlighter;
    public void Show(bool b)
    {
        highlighter.gameObject.SetActive(b);
    }

    public void SetSize(int width, int height)
    {
        Vector2 size = new Vector2(width, height);
        highlighter.sizeDelta = size;
    }

    public void SetPosition(Vector2 pos)
    {
        highlighter.localPosition = pos;
    }
}
