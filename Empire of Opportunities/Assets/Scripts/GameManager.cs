using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private StoreShop[] storeShops;

    public Player player;
    void Start()
    {
        storeShops = FindObjectsOfType<StoreShop>();
        InvokeRepeating("UpdateStoreShopIncome", 0f, 2f);
    }

    void UpdateStoreShopIncome()
    {
        foreach (StoreShop shop in storeShops)
        {
            shop.UpdateIncome(); 
        }

        player.UpgradeCapital();
    }
}
