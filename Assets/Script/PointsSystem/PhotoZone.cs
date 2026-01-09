using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;
using static Mission;

public class PhotoZone : MonoBehaviour
{
    List<PhotoProp> inside = new List<PhotoProp>();
    public DisplayImage3D greenscreen;
    public List<PhotoProp> GetAllProps()
    {
        List<PhotoProp> insideUnique = new List<PhotoProp>();
        foreach (var item in inside)
        {
            if(!insideUnique.Contains(item))insideUnique.Add(item);
        }
        insideUnique.Add(greenscreen.GetProp());
        return insideUnique;
    }


    void OnTriggerEnter(Collider other)
    {
        PhotoPropComponent item = other.GetComponent<PhotoPropComponent>();
        if (item != null) inside.Add(item.prop);
    }

    void OnTriggerExit(Collider other)
    {
        PhotoPropComponent item = other.GetComponent<PhotoPropComponent>();
        if (item != null) inside.Remove(item.prop);
    }
}
