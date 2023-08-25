using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderService: IBuilderService
{
    private int _upgradeCost;
    private int _costBuilding;
    private float _modificatoryCostUpgrade;

    public int upgradeCost => _upgradeCost;
    public int costBuilding => _costBuilding;

    public float modificatoryUpgradeCost => _modificatoryCostUpgrade;

    public void SetUpdateCost(int upgradeCost, int costBuilding, float modificatoryUpgradeCost)
    {
        _upgradeCost = upgradeCost;
        _costBuilding = costBuilding;
        _modificatoryCostUpgrade = modificatoryUpgradeCost;
    }
}
