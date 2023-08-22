using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilderBase
{
    int baseIncomeBuild { get; }

    int costBuilding { get; }

    string name { get; }

    void UpdateBaseIncome();

}
