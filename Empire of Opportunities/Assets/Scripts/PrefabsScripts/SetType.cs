using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class SetType : MonoBehaviour
{
    private BuilderType selectedType;


    private void OnMouseEnter()
    {
        if (gameObject.name == "Shop")
        {
            selectedType = BuilderType.Shop;
            Debug.Log("Set type " + selectedType);
        }
        if (gameObject.name == "DNS")
        {
            selectedType = BuilderType.DNS;
            Debug.Log("Set type " + selectedType);
        }
    }
    public BuilderType SelectedType()
    {
        Debug.Log("return Type " + selectedType);
        return selectedType;
    }
}



