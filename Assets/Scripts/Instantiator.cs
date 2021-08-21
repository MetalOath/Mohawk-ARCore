using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject platform;
    public GameObject currentGameObject;
    public GameObject currentPlatform;
    public GameObject CurrentGameObject { set { currentGameObject = value; } }

    public void ChangePrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
    }
    public void InstantiatePrefab()
    {
        DestroyCurrentGameObject();
        currentGameObject = Instantiate(prefab, transform);
        currentPlatform = Instantiate(platform, transform);
    }

    public void DestroyCurrentGameObject()
    {
        if (currentGameObject)
            Destroy(currentGameObject);
        if (currentPlatform)
            Destroy(currentPlatform);
    }
}