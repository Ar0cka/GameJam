using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilderService
{
    int upgradeCost {  get;}
    int costBuilding { get;}
    float modificatoryUpgradeCost { get; }

    void SetUpdateCost(int upgradeCost, int costBuilding, float modificatoryUpgradeCost);
}
