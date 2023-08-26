using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Salesman : PersonalAbstract
{

    private void Start()
    {
        CreateFactoryPersonal();

        InvokeRepeating("AddToCapitalMainPlayer", 0, 2f);

        UpdatePersonalService();

        UpgradeTextPersonal();
    }

    public void ChangeShopService()
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
        if (_buildableState != null && _buildableState.IsBuildableShop && _upgradePersonal.LevelPersonal > 0)
        {
            IncomeController.instance.IncreaseCapital(_basePersonal.BaseIncome);
        } 
    }

    protected override void CreateFactoryPersonal()
    {
        _basePersonal = _factoryPersonal.CreateBasePersonal("Salesman", 1);
        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 50);
    }
}
