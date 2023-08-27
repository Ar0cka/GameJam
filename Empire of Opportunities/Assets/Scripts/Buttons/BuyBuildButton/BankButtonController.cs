using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BankButtonController : AbstractButtonBuy
{
    [SerializeField] private Bank bank;
    protected override void Awake()
    {
        buyButton.onClick.AddListener(OnClick);
        buyButton.gameObject.SetActive(false);
    }
    private void OnEnableService()
    {
        if (_buildableState.IsBuildableBank)
            bank.OnChangeBuilderService += HandheldBuildServiceChange;
    }
    private void OnDisableService()
    {
        if (_buildableState.IsBuildableBank)
            bank.OnChangeBuilderService -= HandheldBuildServiceChange;
    }
    protected override void BuildingTypeSelected()
    {
        _buildableState.SetBank();
        bank.ChangeBuildService();
    }
    private void HandheldBuildServiceChange(IBuilderService builderService)
    {
        _builderService = builderService;
    }
    protected override void OnClick()
    {
        if (canBuild)
            BuildingTypeSelected();

        if (_buildableState.IsBuildableBank)
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
        if (_buildableState.IsBuildableBank)
        {
            bank.ChangeUIBuilder();
        }
    }
}
