using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilder : IFactoryBuild
{
    public IBuilderBase CreateBuilderBase(string _name, int _baseIncomeBuild, int _costBuilding)
    {
        return new BuilderBase(_name, _baseIncomeBuild,_costBuilding);
    }

    public IUpgradeBuild CreateUpgradeBuild(int _upgradeCost, int _level, int _modificatoryUpgradeCost)
    {
        return new UpgradeBuild(_upgradeCost, _level, _modificatoryUpgradeCost);
    }
}
