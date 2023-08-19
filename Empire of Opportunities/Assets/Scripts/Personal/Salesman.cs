using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Salesman : MonoBehaviour
{
    [SerializeField] private UIViewManager _viewer;

    [SerializeField] private MainPlayer _mainPlayer;

    [Inject] private IFactoryPersonal _factoryPersonal;
    [Inject] private IBuildableState _buildableState;
    [Inject] private IPesonalService _personalService;

    private IBasePersonal _basePersonal;
    private IUpgradePersonal _upgradePersonal;

    private int upgradeIncomePersonal = 2;
    private void Start()
    {
        _basePersonal = _factoryPersonal.CreateBasePersonal("Salesman", 1);
        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 50);

        _personalService.UpgradeCostPersonal(_upgradePersonal.UpgradeCostPersonal);

        InvokeRepeating("AddToCapitalMainPlayer", 0, 2f);

        UpgradeTextMeshPro();
    }

    public void UpgradeTextMeshPro()
    {
        _viewer.Personal(_basePersonal.Name, _basePersonal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal);
    }

    public void UpgradeCost()
    {
        _upgradePersonal.UpdateCostUpgradePersonal();

        _personalService.UpgradeCostPersonal(_upgradePersonal.UpgradeCostPersonal);

        _basePersonal.UpdateBaseIncome(upgradeIncomePersonal);
    }

    private void AddToCapitalMainPlayer()
    {
        if (_buildableState != null && _buildableState.IsBuildable && _upgradePersonal.LevelPersonal > 0)
        {
            _mainPlayer.AddToTotalCapital(_basePersonal.BaseIncome);
        } 
    }
}
