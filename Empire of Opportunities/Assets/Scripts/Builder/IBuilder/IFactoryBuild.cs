using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryBuild
{
    IBuilderBase CreateBuilderBase(string name, int baseIncomeBuild, int costBuilding);

    IUpgradeBuild CreateUpgradeBuild(int upgradeCost, int level, int modificatoryUpgradeCost);
}
