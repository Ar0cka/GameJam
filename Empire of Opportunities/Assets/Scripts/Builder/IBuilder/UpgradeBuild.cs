using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuild : IUpgradeBuild
{
    private int _upgradeCost;
    private int _level;
    private int _modificatoryUpgradeCost;

    public int upgradeCost => _upgradeCost;
    public int level => _level;
    public int modificatoryUpgradeCost => _modificatoryUpgradeCost;

    public UpgradeBuild(int upgradeCost, int level, int modificatoryUpgradeCost)
    {
        _upgradeCost = upgradeCost;
        _level = level;
        _modificatoryUpgradeCost = modificatoryUpgradeCost;
    }

    public void UpgradeLevelBuild()
    {
        _level++;
        _upgradeCost = _upgradeCost * _modificatoryUpgradeCost;
    }
}
