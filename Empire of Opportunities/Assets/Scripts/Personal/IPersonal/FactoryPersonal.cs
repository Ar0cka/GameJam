using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPersonal : MonoBehaviour, IFactoryPersonal
{
   public IBasePersonal CreateBasePersonal(string name, int baseIncome)
    {
        GameObject basePersonalGO = new GameObject(name);
        var basePersonal = basePersonalGO.AddComponent<BasePersonal>();
        basePersonal.Initialize(name, baseIncome);
        return basePersonal;
    }
    public IUpgradePersonal CreateUpgradePersonal(int level, int upgradeCost)
    {
        GameObject upgradePersonalGO = new GameObject("UpgradePersonal");
        var upgradePersonal = upgradePersonalGO.AddComponent<UpgradePersonal>();
        upgradePersonal.Initialize(level, upgradeCost);
        return upgradePersonal;
    }
}
