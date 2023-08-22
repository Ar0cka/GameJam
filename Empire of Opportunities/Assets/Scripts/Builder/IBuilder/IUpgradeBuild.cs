using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeBuild
{
    int upgradeCost { get; }
    int level { get; }

    int modificatoryUpgradeCost { get; }

    void UpgradeLevelBuild();


}
