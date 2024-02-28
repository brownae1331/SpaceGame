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

    public void SetPosition(Vector2 pos)
    {
        highlighter.localPosition = pos;
    }
}
