using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DNSUpgradeButton : AbstractUpgradeCost
{
    [Header("DNS")]
    [SerializeField] private DNSControllerBuild _dns;

    #region EnableOrDisable
    private void OnEnable()
    {
        _dns.OnChangeBuilderService += HandlerChangeService;
    }
    private void OnDisable()
    {
        _dns.OnChangeBuilderService -= HandlerChangeService;
    }
    #endregion

    private void Update()
    {
        if (_deduct.currentCapital >= _builderService.upgradeCost && _buildableState.IsBuildableDNS)
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
        if (_buildableState.IsBuildableDNS)
        {
            if (canUpgrade)
            {
                _deduct.UpdateCapital(_builderService.upgradeCost);
                _dns.ChangeBuildService();
                _dns.upgradeCost();
            }
            _dns.ChangeUIBuilder();
        }
    }
}
