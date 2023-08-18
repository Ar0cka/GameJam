using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UpgradePersonal : MonoBehaviour, IUpgradePersonal
{
    private int _upgradeCostPersonal;
    private int _levelPersonal;
    public int UpgradeCostPersonal => _upgradeCostPersonal;
    public int LevelPersonal => _levelPersonal;

    public void Initialize(int levelPersonal, int upgradeCost) 
    {
        _levelPersonal = levelPersonal;
        _upgradeCostPersonal = upgradeCost; 
    }

    public void UpdateCostUpgradePersonal()
    {
        _levelPersonal++;
        _upgradeCostPersonal = _upgradeCostPersonal * _levelPersonal;
    }
}
