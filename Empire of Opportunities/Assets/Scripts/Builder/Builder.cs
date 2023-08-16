using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    protected int initialIncome = 2;
    protected int upgradeCost = 200;
    private int level = 1;

    protected int _income;

    protected float locationMultiplayer;
    protected float upgradeMultiplayer;

    public int Income => _income;
    public int _level => level;

    public int _isUpdateCost => upgradeCost;
    
    private int UpdateUpgradeCost()
    {
        return Mathf.RoundToInt(upgradeCost * 2);
    }

    private void UpgradeLevel()
    {
        level++;
        initialIncome = level * initialIncome;
        upgradeCost = UpdateUpgradeCost();
    }

    public virtual void UpdateLevel()
    {
        UpgradeLevel();
    }

    public virtual void UpdateIncome()
    {
       CalculatIncome();
    }
    
    private void CalculatIncome()
    {
        float incomeCapital = initialIncome * locationMultiplayer * upgradeMultiplayer;
        _income = (int)incomeCapital;
    }
}
