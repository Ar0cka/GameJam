using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Manager : PersonalAbstract
{
    private void Start()
    {
        CreateFactoryPersonal();

        InvokeRepeating("AddToCapitalMainPlayer", 0, 2f);

        UpdatePersonalService();

        UpgradeTextPersonal();
    }

    public void ChangeDNSService()
    {
        UpgradeTextPersonal();
        UpdatePersonalService();
    }
    public void UpdatePersonal()
    {
        UpgradePersonal();
    }

    private void AddToCapitalMainPlayer()
    {
        if (_buildableState != null && _buildableState.IsBuildableDNS && _upgradePersonal.LevelPersonal > 0)
        {
            IncomeController.instance.IncreaseCapital(_basePersonal.BaseIncome);
        }
    }

    protected override void CreateFactoryPersonal()
    {
        _basePersonal = _factoryPersonal.CreateBasePersonal("Manager", 4);
        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 100);
    }
}
