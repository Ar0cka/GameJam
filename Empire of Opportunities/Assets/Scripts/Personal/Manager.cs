using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Manager : MonoBehaviour
{
    [Inject] IFactoryPersonal _factoryPersonal;
    [Inject] IBuildableState _buildableState;

    [SerializeField] UIViewManager _viewManager;
    [SerializeField] MainPlayer _mainPlayer;

    IBasePersonal _personal;
    IUpgradePersonal _upgradePersonal;

    public int upgradeCost;

    private int upgradeIncomeManager = 4;
    private void Start()
    {
        _personal = _factoryPersonal.CreateBasePersonal("Manager", 4);

        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 100);

        upgradeCost = _upgradePersonal.UpgradeCostPersonal;

        InvokeRepeating("AddToCapitalIncomeManager", 0, 2);

        _viewManager.ManagerPersonal(_personal.Name, _personal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal);
    }
    public void UpgradeTexManager()
    {
        _viewManager.ManagerPersonal(_personal.Name, _personal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal);
    }
    public void UpdateCost()
    {
            _upgradePersonal.UpdateCostUpgradePersonal();

            upgradeCost = _upgradePersonal.UpgradeCostPersonal;

            _personal.UpdateBaseIncome(upgradeIncomeManager); 
    }

    private void AddToCapitalIncomeManager()
    {
        if (_buildableState != null && _buildableState.IsBuildable && _upgradePersonal.LevelPersonal>0)
        {
            _mainPlayer.AddToTotalCapital(_personal.BaseIncome);
        }
    }

}
