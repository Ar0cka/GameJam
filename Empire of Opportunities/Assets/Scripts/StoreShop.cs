using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreShop : Builder
{
    void Start()
    {
        locationMultiplayer = 1.5f;
        upgradeMultiplayer = 2f;
    }

    public override void UpdateIncome()
    {
       base.UpdateIncome();

       Player player = FindAnyObjectByType<Player>();

       player.AddToTotalCapital(Income);
    }
}
