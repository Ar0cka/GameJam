using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Manager : MonoBehaviour
{

    [Inject] IFactoryPersonal _factoryPersonal;
    [Inject] IBuildableState _buildableState;
    [Inject] IPesonalService _personalService;

    [SerializeField] UIViewManager _viewManager;
    [SerializeField] TextMeshProUGUI _descriptionManager;

    [SerializeField] MainPlayer _mainPlayer;

    IBasePersonal _personal;
    IUpgradePersonal _upgradePersonal;

    private int upgradeIncomeManager = 4;

    public event Action<IPesonalService> OnPersonalServiceChange;

    private void Start()
    {
        CreateCopyInterface();

        InvokeRepeating("AddToCapitalIncomeManager", 0, 2);

        UpdateCostService();

        UpdateManagerUI();
    }
    private void ChangePersonalService(IPesonalService newPersonalService)
    {
        _personalService = newPersonalService;
        OnPersonalServiceChange?.Invoke(_personalService);
    }
    public void UpdateManagerUI()
    {
        _viewManager.SetPersonalText(_personal.Name, _personal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal, _descriptionManager);
    }
    public void UpdateCost()
    {
        _upgradePersonal.UpdateCostUpgradePersonal();
        UpdateCostService();
        _personal.UpdateBaseIncome(upgradeIncomeManager); 
    }

    private void AddToCapitalIncomeManager()
    {
        if (_buildableState != null && _buildableState.IsBuildable && _upgradePersonal.LevelPersonal>0)
        {
            _mainPlayer.AddToTotalCapital(_personal.BaseIncome);
        }
    }
    private void UpdateCostService()
    {
        _personalService.UpgradeCostPersonal(_upgradePersonal.UpgradeCostPersonal, _upgradePersonal.LevelPersonal);

        ChangePersonalService(_personalService);
    }
    private void CreateCopyInterface()
    {
        _personal = _factoryPersonal.CreateBasePersonal("Manager", 4);

        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 100);
    }
}
