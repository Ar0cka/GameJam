using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Net;

public class ShopButtonController : AbstractButtonBuy
{
    [SerializeField] private StoreShop shop;
    protected override void Awake()
    {
        buyButton.onClick.AddListener(OnClick);
        buyButton.gameObject.SetActive(false);
    }
    private void OnEnableService()
    {
        if (_buildableState.IsBuildableShop)
            shop.OnChangeBuilderService += HandheldBuildServiceChange;
    }
    private void OnDisableService()
    {
        if (_buildableState.IsBuildableShop)
            shop.OnChangeBuilderService -= HandheldBuildServiceChange;
    }
    protected override void BuildingTypeSelected()
    {
            _buildableState.SetBuilderShop();
            shop.ChangeBuildService();
    }
    private void HandheldBuildServiceChange(IBuilderService builderService)
    {
        _builderService = builderService;
    }
    protected override void OnClick()
    {
      if (canBuild)
            BuildingTypeSelected();

      if (_buildableState.IsBuildableShop)
      {
          OnEnableService();
          if (canBuild)
          {
             mainPlayer.Build(_builderService.costBuilding);

             CheckBuildableState();

             Contract();

             Purchase();
             OnDisableService();
          }
      }

    }
    protected override void CheckBuildableState()
    {
        if (_buildableState.IsBuildableShop)
        {
            shop.ChangeUIBuilder();
        }
    }
}
