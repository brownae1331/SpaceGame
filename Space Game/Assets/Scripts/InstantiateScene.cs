using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class InstantiateScene : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;

    private void Start()
    {
        foreach (GameObject gameObject in objects)
        {
            Instantiate(gameObject);
        }
    }
}
