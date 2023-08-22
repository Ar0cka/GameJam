using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBase : IBuilderBase
{
    private string _name;

    private int _baseIncomeBuild;

    private int _costBuilding;

    public int costBuilding => _costBuilding;

    public int baseIncomeBuild => _baseIncomeBuild;

    public string name => _name;

    public BuilderBase(string name, int baseIncomeBuild, int costBuilding)
    {
        _name = name;
        _baseIncomeBuild = baseIncomeBuild;
        _costBuilding = costBuilding;   
    }

    public void UpdateBaseIncome()
    {
        _baseIncomeBuild += 2;
    }

}
