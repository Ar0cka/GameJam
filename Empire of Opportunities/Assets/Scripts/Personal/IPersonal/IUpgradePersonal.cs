using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradePersonal
{
    int UpgradeCostPersonal { get; }
    int LevelPersonal { get; }

    void UpdateCostUpgradePersonal();
}
