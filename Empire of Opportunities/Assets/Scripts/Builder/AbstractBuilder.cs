using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class AbstractBuilder : MonoBehaviour
{
    [Inject] protected IBuilderService buildableService;
    [Inject] protected IBuildableState buildableState;
    [Inject] protected IFactoryBuild factoryBuild;

    protected IBuilderBase builderBase;
    protected IUpgradeBuild upgradeBuild;

    [Header("UI")]
    [SerializeField] protected UIViewManager _viewer;
    [SerializeField] protected TextMeshProUGUI _informationBuild;
    [Header("Player")]
    protected IncomeController _incomePlayer;

    protected abstract void Start();

    public event Action <IBuilderService> OnChangeBuilderService;


    protected abstract void TransferringPlayerData();
    protected abstract void FactoryCreateBuild();
    protected void ChangeBuilderService(IBuilderService _buildableService)
    {
        this.buildableService = _buildableService;
        OnChangeBuilderService?.Invoke(buildableService);
    }


}
