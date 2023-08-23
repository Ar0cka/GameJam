using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using static UnityEditor.ObjectChangeEventStream;

public class StoreShop : AbstractBuilder
{
    protected override void Start()
    {
        FactoryCreateBuild();
        
        InvokeRepeating("TransferringPlayerData", 0f, 2f);

        ChangeBuildService();

        ChangeUIBuilder();
    }
    public void upgradeCost()
    {
        if (CanBuild()) 
        {
            UpdateBuildAndIncome();
        } 
    }

    protected override void TransferringPlayerData()
    { 
        if (CanBuild()) 
        {
            IncomeController.instance.IncreaseCapital(builderBase.baseIncomeBuild);
        }
    }
    public void ChangeUIBuilder()
    {
        if (CanBuild())
        {
            _viewer.BuildView(builderBase.name, builderBase.baseIncomeBuild, upgradeBuild.level, upgradeBuild.upgradeCost, _informationBuild);
        }
        else
        {
            _viewer.BuildView(builderBase.name, builderBase.baseIncomeBuild, builderBase.costBuilding, upgradeBuild.level, upgradeBuild.upgradeCost, _informationBuild);
        }
        
    }

    protected override void FactoryCreateBuild()
    {
        builderBase = factoryBuild.CreateBuilderBase("Shop", 2, 300);
        upgradeBuild = factoryBuild.CreateUpgradeBuild(200, 0, 2);
    }
    private void UpdateBuildAndIncome()
    {
        upgradeBuild.UpgradeLevelBuild();
        builderBase.UpdateBaseIncome();
    }
    public void ChangeBuildService()
    {
        buildableService.SetUpdateCost(upgradeBuild.upgradeCost, builderBase.costBuilding, upgradeBuild.modificatoryUpgradeCost);
        ChangeBuilderService(buildableService);
    }
}
