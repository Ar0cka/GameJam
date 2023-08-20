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

    private IBuildableState _buildableState;
    [Inject]
    private void InjectDependencies(IBuildableState buildableState)
    {
        _buildableState = buildableState;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

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
        if (_buildableState != null && _buildableState.IsBuildable)
        {
            mainPlayer.Build(shop._isCostBuild);
            shop.UpdateIncome();

            if (contract != null)
            {
                contract.gameObject.SetActive(true);
                contract.StartDisplay();
            }

            _viewer.IncomeView(shop.InitialIncome);
            _viewer.CostView(shop.UpdateCost);

            Purchase();
        } 
    }

    private void Purchase()
    {
        Destroy(buyButton.gameObject);
    }
}
