using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public List<GameObject> targets = new List<GameObject>();

    public void OnEnable()
    {
        manager.trackedImagesChanged += Reader;
    }
    public void OnDisable()
    {
        manager.trackedImagesChanged -= Reader;
    }
    public void Reader(ARTrackedImagesChangedEventArgs arg)
    {
        foreach(ARTrackedImage image in arg.added)
        {
            EnableGameObject(image.referenceImage.name, true);
        }
        foreach (ARTrackedImage image in arg.updated)
        {
            PositionGameObject(image.referenceImage.name, image.transform.position);
        }
        foreach(ARTrackedImage image in arg.removed)
        {
            EnableGameObject(image.referenceImage.name, false);
        }
    }
    public void EnableGameObject(string refName, bool state)
    {
        GameObject targetGameObject = targets.Find(item => item.name == refName);
        targetGameObject.SetActive(state);
    }
    public void PositionGameObject(string refName, Vector3 position)
    {
        GameObject targetGameObject = targets.Find(item => item.name == refName);
        targetGameObject.transform.position = position;
    }
}