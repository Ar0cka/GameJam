using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public abstract class PersonalAbstract : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] protected UIViewManager _viewer;
    [SerializeField] protected TextMeshProUGUI _descriptionPersonal;
    [Header("Income")]
    [SerializeField] protected int upgradeBaseIncome;
    [Header("Player")]
    [SerializeField] protected MainPlayer _mainPlayer;

    [Inject] protected IFactoryPersonal _factoryPersonal;
    [Inject] protected IBuildableState _buildableState;
    [Inject] protected IPesonalService _personalService;

    public event Action<IPesonalService> OnServiceChange;

    protected IBasePersonal _basePersonal;
    protected IUpgradePersonal _upgradePersonal;

    protected void ChangePersonalService(IPesonalService personalService)
    {
        _personalService = personalService;
        OnServiceChange?.Invoke(_personalService);
    }
    public void UpgradeTextPersonal()
    {
        _viewer.SetPersonalText(_basePersonal.Name, _basePersonal.BaseIncome, _upgradePersonal.LevelPersonal, _upgradePersonal.UpgradeCostPersonal, _descriptionPersonal);
        Debug.Log("Viewer " + _viewer + " descriptionPersonal " +  _descriptionPersonal);
    }
    protected void UpgradePersonal()
    {
        _upgradePersonal.UpdateCostUpgradePersonal();
        _basePersonal.UpdateBaseIncome(upgradeBaseIncome);
    }

    protected void UpdatePersonalService()
    {
        _personalService.UpgradeCostPersonal(_upgradePersonal.UpgradeCostPersonal, _upgradePersonal.LevelPersonal);
        ChangePersonalService(_personalService);
    }

    protected abstract void CreateFactoryPersonal();
}
