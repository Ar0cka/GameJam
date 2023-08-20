using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalService: IPesonalService
{
    private int _upgradeCost;
    private int _level;

    public int upgradeCost => _upgradeCost;
    public int level => _level;

    public void UpgradeCostPersonal(int upgradeCost, int level)
    {
        _upgradeCost = upgradeCost;
        _level = level;
    }
}
