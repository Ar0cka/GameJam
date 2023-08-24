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
        if (buildableState.IsBuildableShop) 
        {
            UpdateBuildAndIncome();
        } 
    }

    protected override void TransferringPlayerData()
    {
        //Debug.Log("Shop " + buildableState.IsBuildableShop);
        if (buildableState.IsBuildableShop) 
        {
            IncomeController.instance.IncreaseCapital(builderBase.baseIncomeBuild);
        }
    }
    public void ChangeUIBuilder()
    {
        if (buildableState.IsBuildableShop)
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
        builderBase = factoryBuild.CreateBuilderBase("Shop", 2, 25);
        upgradeBuild = factoryBuild.CreateUpgradeBuild(25, 0, 7);
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
