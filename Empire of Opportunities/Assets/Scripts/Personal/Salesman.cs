using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Salesman : MonoBehaviour
{

    [SerializeField] private UIViewManager _viewer;

    [SerializeField] private TextMeshProUGUI _descriptionSalesman;

    [SerializeField] private MainPlayer _mainPlayer;

    [Inject] private IFactoryPersonal _factoryPersonal;
    [Inject] private IBuildableState _buildableState;
    [Inject] private IPesonalService _personalSalesmanService;

    public event Action<IPesonalService> OnSalesmanServiceChange;

    private IBasePersonal _basePersonal;
    private IUpgradePersonal _upgradePersonal;

    private int upgradeIncomePersonal = 2;

    private void Start()
    {
        CreateFactorySalesman();

        InvokeRepeating("AddToCapitalMainPlayer", 0, 2f);

        UpdatePersonalService();

        UpgradeTextSalesMan();
    }

    public void ChangePersonalService(IPesonalService personalService)
    {
        _personalSalesmanService = personalService;
        OnSalesmanServiceChange?.Invoke(_personalSalesmanService);
    }

    public void UpgradeTextSalesMan()
    {
        _viewer.SetPersonalText(_basePersonal.Name, _basePersonal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal, _descriptionSalesman);
    }

    public void UpgradeCost()
    {
        _upgradePersonal.UpdateCostUpgradePersonal();
        _basePersonal.UpdateBaseIncome(upgradeIncomePersonal);
    }

    private void AddToCapitalMainPlayer()
    {
        if (_buildableState != null && _buildableState.IsBuildableShop && _upgradePersonal.LevelPersonal > 0)
        {
            IncomeController.instance.IncreaseCapital(_basePersonal.BaseIncome);
        } 
    }

    public void UpdatePersonalService()
    {
        _personalSalesmanService.UpgradeCostPersonal(_upgradePersonal.UpgradeCostPersonal, _upgradePersonal.LevelPersonal) ;
        ChangePersonalService(_personalSalesmanService);
    }

    private void CreateFactorySalesman()
    {
        _basePersonal = _factoryPersonal.CreateBasePersonal("Salesman", 1);
        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 50);
    }
}
