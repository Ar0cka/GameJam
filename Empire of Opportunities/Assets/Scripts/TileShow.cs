using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileShow : MonoBehaviour
{ 
    [SerializeField] private Button buyButton;

    [SerializeField] private Contract contract;

    private void Start()
    {
        buyButton.onClick.AddListener(OnClick);
        buyButton.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        if(buyButton != null)   
        buyButton.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        if(buyButton != null)
        buyButton?.gameObject.SetActive(false);
    }

    private void OnClick()
    {
        contract.gameObject.SetActive(true);
        contract.StartDisplay();    
        Purchase();
    }

    private void Purchase()
    {
        Destroy(buyButton.gameObject);
    }

}
