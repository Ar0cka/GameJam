using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreShop : Builder
{ 
    void Start()
    {
        locationMultiplayer = 1.5f;
        upgradeMultiplayer = 2f;
        InvokeRepeating("UpdateIncome", 0f, 2f);
        
    }

    public override void UpdateIncome()
    {
      if (BuildableState.Instance != null && BuildableState.Instance.IsBuildable)
        {
            base.UpdateIncome();

            TransferringPlayerData();
        }
    }
    private void TransferringPlayerData()
    { 
        Player player = FindAnyObjectByType<Player>();

        player.AddToTotalCapital(Income);

        player.UpgradeCapital();
    }
}
