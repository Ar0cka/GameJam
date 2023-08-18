using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class StoreShop : Builder
{
    [SerializeField] private UIViewManager _viewer;

    public int _isCostBuild => costBuilding;

    private IBuildableState _buildableState;

    [Inject]
    public StoreShop(IBuildableState buildableState)
    {
        _buildableState = buildableState;
    }

    void Start()
    {
        costBuilding = 200;
        _locationMultiplayer = 1.5f;
        InvokeRepeating("UpdateIncome", 0f, 2f);   
    }
    public override void UpdateLevel()
    {
        if (_buildableState != null && _buildableState.IsBuildable) 
        {
            base.UpdateLevel();
        } 
    }
    public void UpdateIncome()
    {
      if (_buildableState != null && _buildableState.IsBuildable)
        {
            TransferringPlayerData();
        }
    }
    private void TransferringPlayerData()
    { 
        MainPlayer player = FindAnyObjectByType<MainPlayer>();

        player.AddToTotalCapital(initialIncome);

    }
    private void Update()
    {
        if (_buildableState != null && _buildableState.IsBuildable)
        {
            _viewer.LevelView(Level);
        }
    }
}
