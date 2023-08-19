using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalService: IPesonalService
{
    private int _upgradeCost;

    public int upgradeCost => _upgradeCost;

    public void UpgradeCostPersonal(int amount)
    {
        _upgradeCost = amount;
    }
}
