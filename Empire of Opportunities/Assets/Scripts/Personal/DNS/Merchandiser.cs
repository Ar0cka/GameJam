using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchandiser : PersonalAbstract
{
    private void Start()
    {
        CreateFactoryPersonal();

        InvokeRepeating("AddToCapitalMainPlayer", 0, 2f);

        UpdatePersonalService();

        UpgradeTextPersonal();
    }

    public void ChangeMerchandiserService()
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
        _basePersonal = _factoryPersonal.CreateBasePersonal("Merchandiser", 23);
        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 300);
    }
}
