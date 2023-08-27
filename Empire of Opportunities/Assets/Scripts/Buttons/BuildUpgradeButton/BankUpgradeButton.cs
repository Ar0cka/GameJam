using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankUpgradeButton : AbstractUpgradeCost
{
    [Header("Bank")]
    [SerializeField] private Bank bank;

    #region EnableOrDisable
    private void OnEnable()
    {
        bank.OnChangeBuilderService += HandlerChangeService;
    }
    private void OnDisable()
    {
        bank.OnChangeBuilderService -= HandlerChangeService;
    }
    #endregion

    private void Update()
    {
        if (_deduct.currentCapital >= _builderService.upgradeCost && _buildableState.IsBuildableBank)
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
        if (_buildableState.IsBuildableBank)
        {
            if (canUpgrade)
            {
                _deduct.UpdateCapital(_builderService.upgradeCost);
                bank.ChangeBuildService();
                bank.upgradeCost();
            }
            bank.ChangeUIBuilder();
        }
    }
}
