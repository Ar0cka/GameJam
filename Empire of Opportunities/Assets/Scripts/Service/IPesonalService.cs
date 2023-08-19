using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPesonalService
{
    int upgradeCost { get; }

    void UpgradeCostPersonal(int amount);
}
