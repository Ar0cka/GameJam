using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    protected int initialIncome = 2;
    protected int upgradeCost = 200;
    private int level = 1;
    protected int costBuilding;
   

    protected float locationMultiplayer;
    protected float upgradeMultiplayer;

    public int Income => initialIncome;
    public int Level => level;

    public int UpdateCost => upgradeCost;
    
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
    }
}
