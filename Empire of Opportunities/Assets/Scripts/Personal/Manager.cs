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
    [Inject] IPesonalService _personalManagerService;

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
        _personalManagerService = newPersonalService;
        OnPersonalServiceChange?.Invoke(_personalManagerService);
    }
    public void UpdateManagerUI()
    {
        _viewManager.SetPersonalText(_personal.Name, _personal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal, _descriptionManager);
    }
    public void UpdateCost()
    {
        _upgradePersonal.UpdateCostUpgradePersonal();
        _personal.UpdateBaseIncome(upgradeIncomeManager); 
    }

    private void AddToCapitalIncomeManager()
    {
        if (_buildableState != null && _buildableState.IsBuildableShop && _upgradePersonal.LevelPersonal>0)
        {
            IncomeController.instance.IncreaseCapital(_personal.BaseIncome);
        }
    }
    public void UpdateCostService()
    {
        _personalManagerService.UpgradeCostPersonal(_upgradePersonal.UpgradeCostPersonal, _upgradePersonal.LevelPersonal);

        ChangePersonalService(_personalManagerService);
    }
    private void CreateCopyInterface()
    {
        _personal = _factoryPersonal.CreateBasePersonal("Manager", 4);

        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 100);
    }
}
