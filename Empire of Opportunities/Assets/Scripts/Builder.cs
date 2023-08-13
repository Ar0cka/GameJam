using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    public int InitialIncome = 2;
    public int UppgradeCost = 200;

    protected int _income;

    protected float locationMultiplayer;
    protected float upgradeMultiplayer;

    public int Income => _income;
   

    public virtual void UpdateIncome()
    {
        float incomeCapital = InitialIncome * locationMultiplayer * upgradeMultiplayer;
        _income = (int)incomeCapital;
    }
}
