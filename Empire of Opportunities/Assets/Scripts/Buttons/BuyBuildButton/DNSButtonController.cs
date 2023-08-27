using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.Asteroids;

public class DNSButtonController : AbstractButtonBuy
{
    [SerializeField] private DNS dns;
    protected override void Awake()
    {
        buyButton.onClick.AddListener(OnClick);
        buyButton.gameObject.SetActive(false);
    }
    private void OnEnableService()
    {
        if (_buildableState.IsBuildableDNS)
            dns.OnChangeBuilderService += HandheldBuildServiceChange;
    }
    private void OnDisableService()
    {
        if (_buildableState.IsBuildableDNS)
            dns.OnChangeBuilderService -= HandheldBuildServiceChange;
    }
    protected override void BuildingTypeSelected()
    {
            _buildableState.SetBuilderDNS();
            dns.ChangeBuildService();
    }
    private void HandheldBuildServiceChange(IBuilderService builderService)
    {
        _builderService = builderService;
    }
    protected override void OnClick()
    {
        if (canBuild)
            BuildingTypeSelected();

        if (_buildableState.IsBuildableDNS)
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
        if (_buildableState.IsBuildableDNS)
        {
            dns.ChangeUIBuilder();
        }
    }
}
