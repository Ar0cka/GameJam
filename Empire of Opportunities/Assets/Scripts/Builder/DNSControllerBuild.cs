using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNSControllerBuild : AbstractBuilder
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
        if (buildableState.IsBuildableDNS)
        {
            UpdateBuildAndIncome();
        }
    }

    protected override void TransferringPlayerData()
    {
        if (buildableState.IsBuildableDNS)
        {
            IncomeController.instance.IncreaseCapital(builderBase.baseIncomeBuild);
        }
    }
    public void ChangeUIBuilder()
    {
        if (buildableState.IsBuildableDNS)
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
        builderBase = factoryBuild.CreateBuilderBase("DNS", 15, 100);
        upgradeBuild = factoryBuild.CreateUpgradeBuild(50, 0, 17);
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
