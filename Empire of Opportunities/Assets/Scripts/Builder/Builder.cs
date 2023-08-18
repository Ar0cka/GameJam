using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    protected int initialIncome = 2;
    protected int upgradeCost = 200;
    private int level = 1;
    protected int costBuilding;
   

    protected float _locationMultiplayer;
    protected float _upgradeMultiplayer;

    public int Level => level;

    public int InitialIncome => initialIncome;

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
}
