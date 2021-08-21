using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class MaterialChange : MonoBehaviour
{
    public ARFaceManager ARFaceManager;
    public List<Material> materials = new List<Material>();
    private int index;

    [System.Serializable]
    public class StringUnityEvent : UnityEvent<string> { }
    public StringUnityEvent materialUpdated;

    public void ChangeMaterial(int newMaterialIndex)
    {
        Material newMaterial = materials[newMaterialIndex];

        foreach (ARFace face in ARFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = newMaterial;
        }

        materialUpdated?.Invoke(newMaterial.name);
        index = newMaterialIndex;
    }

    public void NextMaterial()
    {
        int nextIndex = index + 1;

        if (nextIndex >= materials.Count)
        {
            nextIndex = 0;
        }

        ChangeMaterial(nextIndex);
    }
}
