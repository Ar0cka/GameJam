using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopUpgradeButton : AbstractUpgradeCost
{
    [Header("Shop")]
    [SerializeField] private StoreShop _shop;

    private void OnEnable()
    {
        if (_buildableState.IsBuildableShop) 
           _shop.OnChangeBuilderService += HandlerChangeService;
    }
    private void OnDisable()
    {
        if (_buildableState.IsBuildableShop)
           _shop.OnChangeBuilderService -= HandlerChangeService;
    }

    private void Update()
    {
        if (_deduct.currentCapital >= _builderService.upgradeCost && _buildableState.IsBuildableShop)
        {
            _upgradeLevel.interactable = true;
        }
        else
        {
            _upgradeLevel.interactable = false;
        }
    }

    protected override void OnClickUpgrade()
    {
        if (_buildableState.IsBuildableShop)
        {
            if (_deduct.currentCapital >= _builderService.upgradeCost)
            {
                _deduct.UpdateCapital(_builderService.upgradeCost);              
                _shop.ChangeBuildService();
                _shop.upgradeCost();
            }
            _shop.ChangeUIBuilder();
        }
    }
}
