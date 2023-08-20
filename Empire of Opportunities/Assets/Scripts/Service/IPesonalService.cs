using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPesonalService
{
    int upgradeCost { get; }

    int level { get; }

    void UpgradeCostPersonal(int upgradeCost, int level );
}
