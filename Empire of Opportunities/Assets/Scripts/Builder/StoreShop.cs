using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreShop : Builder
{
    [SerializeField] private UIViewManager _viewer;

    public int _isCostBuild => costBuilding;

    void Start()
    {
        costBuilding = 200;
        locationMultiplayer = 1.5f;
        upgradeMultiplayer = 2f;
        InvokeRepeating("UpdateIncome", 0f, 2f);   
    }
    public override void UpdateLevel()
    {
        if (BuildableState.Instance != null && BuildableState.Instance.IsBuildable) 
        {
            base.UpdateLevel();
        } 
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
        MainPlayer player = FindAnyObjectByType<MainPlayer>();

        player.AddToTotalCapital(Income);

    }
    private void Update()
    {
        if (BuildableState.Instance != null && BuildableState.Instance.IsBuildable)
        {
            _viewer.LevelView(Level);
        }
    }
}
