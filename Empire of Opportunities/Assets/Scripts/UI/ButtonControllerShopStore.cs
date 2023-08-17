using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerShopStore : MonoBehaviour
{ 
    [SerializeField] private Button buyButton;

    [SerializeField] private Contract contract;

    [SerializeField] private StoreShop shop;

    [SerializeField] private MainPlayer mainPlayer;

   
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
        if (BuildableState.Instance != null)
        {
            BuildableState.Instance.SetBuilded();
        }
        if (BuildableState.Instance != null && BuildableState.Instance.IsBuildable)
        {
            mainPlayer.Build(shop._isCostBuild);
            shop.UpdateIncome();

            if (contract != null)
            {
                contract.gameObject.SetActive(true);
                contract.StartDisplay();
            }

            Purchase();
        } 
    }

    private void Purchase()
    {
        Destroy(buyButton.gameObject);
    }

}
