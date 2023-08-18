using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Salesman : MonoBehaviour
{
    [SerializeField] private UIViewManager _viewer;

    [Inject] private IFactoryPersonal _factoryPersonal;

    public int updateCost;

    private void Start()
    {
        IBasePersonal basePersonal = _factoryPersonal.CreateBasePersonal("Salesman", 1);
        IUpgradePersonal upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 50);
        updateCost = upgradePersonal.UpgradeCostPersonal;
        _viewer.Personal(basePersonal.Name, basePersonal.BaseIncome, 
        upgradePersonal.LevelPersonal, upgradePersonal.UpgradeCostPersonal);
    }
}
