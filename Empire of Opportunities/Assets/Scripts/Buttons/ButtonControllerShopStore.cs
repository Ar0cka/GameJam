using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonControllerShopStore : MonoBehaviour
{ 
    [SerializeField] private Button buyButton;

    [SerializeField] private Contract contract;

    [SerializeField] private StoreShop shop;

    [SerializeField] private MainPlayer mainPlayer;

    [SerializeField] private UIViewManager _viewer;

    [Inject] private IBuildableState _buildableState;
    [Inject] private IBuilderService _builderService;

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
        if (_buildableState != null)
        {
            _buildableState.SetBuilded();
        }
        if (CanUpgrade())
        {
            mainPlayer.Build(_builderService.costBuilding);

            if (contract != null)
            {
                contract.gameObject.SetActive(true);
                contract.StartDisplay();
            }

            shop.ChangeUIBuilder();

            Purchase();
        } 
    }
    private bool CanUpgrade()
    {
        return _buildableState != null && _buildableState.IsBuildable;
    }

    private void Purchase()
    {
        Destroy(buyButton.gameObject);
        buyButton.onClick.RemoveListener(OnClick);
    }
}
