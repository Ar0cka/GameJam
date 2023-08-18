using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePersonal : MonoBehaviour, IBasePersonal
{
    private string _name;
    private int _baseIncome;

    public string Name => _name;

    public int BaseIncome => _baseIncome;

    public void Initialize(string name, int baseIncome) 
    {
        _name = name;
        _baseIncome = baseIncome;
    }
}
