using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banker : PersonalAbstract
{
    private void Start()
    {
        CreateFactoryPersonal();

        InvokeRepeating("AddToCapitalMainPlayer", 0, 2f);

        UpdatePersonalService();

        UpgradeTextPersonal();
    }

    public void ChangeBankService()
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
        if (_buildableState != null && _buildableState.IsBuildableBank && _upgradePersonal.LevelPersonal > 0)
        {
            IncomeController.instance.IncreaseCapital(_basePersonal.BaseIncome);
        }
    }

    protected override void CreateFactoryPersonal()
    {
        _basePersonal = _factoryPersonal.CreateBasePersonal("Banker", 70);
        _upgradePersonal = _factoryPersonal.CreateUpgradePersonal(0, 100);
    }
}
