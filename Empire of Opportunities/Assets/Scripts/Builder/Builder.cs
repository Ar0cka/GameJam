using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    protected int InitialIncome = 2;
    protected int UppgradeCost = 200;

    protected int _income;

    protected float locationMultiplayer;
    protected float upgradeMultiplayer;

    public int Income => _income;
   

    public virtual void UpdateIncome()
    {
       CalculatIncome();
    }
    
    private void CalculatIncome()
    {
        float incomeCapital = InitialIncome * locationMultiplayer * upgradeMultiplayer;
        _income = (int)incomeCapital;
    }
}
