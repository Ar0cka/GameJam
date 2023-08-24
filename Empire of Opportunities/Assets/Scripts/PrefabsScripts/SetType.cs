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


    public event Action<BuilderType> OnBuildingTypeSelected;

    private void OnMouseEnter()
    {
        if (gameObject.name == "DNS")
        {
            selectedType = BuilderType.DNS;
            Debug.Log("Set DNS");
        }
        else if (gameObject.name == "Shop")
        {
            selectedType = BuilderType.Shop;
            Debug.Log("Set Shop");
        }
       
    }
    public void BuildTypeSelected()
    {
        Debug.Log("Type selected " +  selectedType);
        OnBuildingTypeSelected?.Invoke(selectedType);
    }
}



