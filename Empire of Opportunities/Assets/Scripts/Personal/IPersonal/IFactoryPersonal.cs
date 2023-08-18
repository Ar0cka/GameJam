using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryPersonal
{
    IBasePersonal CreateBasePersonal(string name, int baseIncome);

    IUpgradePersonal CreateUpgradePersonal(int levelPersonal, int upgradeCost);
}
