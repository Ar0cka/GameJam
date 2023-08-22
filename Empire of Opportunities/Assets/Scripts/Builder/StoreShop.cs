using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class StoreShop : MonoBehaviour
{
    [SerializeField] private UIViewManager _viewer;
    [SerializeField] private MainPlayer _player;
    [SerializeField] private TextMeshProUGUI _informationBuild;
    
    [Inject] private IBuildableState _buildableState;
    [Inject] private IFactoryBuild _factoryBuild;
    [Inject]private IBuilderService _builderService;

    private IBuilderBase _builder;
    private IUpgradeBuild _upgradeBuild;
   
    
    void Start()
    {
        _builder = _factoryBuild.CreateBuilderBase("Shop", 2, 300);
        _upgradeBuild = _factoryBuild.CreateUpgradeBuild(200, 0, 2);
        _builderService.SetUpdateCost(_builder.costBuilding, _upgradeBuild.upgradeCost, _upgradeBuild.modificatoryUpgradeCost);
        ChangeUIBuilder();

        InvokeRepeating("TransferringPlayerData", 0f, 2f);   
    }
    public void upgradeCost()
    {
        if (CanUpgrade()) 
        {
            _builderService.SetUpdateCost(_builder.costBuilding, _upgradeBuild.upgradeCost, _upgradeBuild.modificatoryUpgradeCost);
            _upgradeBuild.UpgradeLevelBuild();
            _builder.UpdateBaseIncome();
        } 
    }

    private bool CanUpgrade()
    {
        return _buildableState!=null && _buildableState.IsBuildable;
    }
    private void TransferringPlayerData()
    { 
        if (CanUpgrade()) 
        {
            _player.AddToTotalCapital(_builder.baseIncomeBuild);
        }
    }
    public void ChangeUIBuilder()
    {
        if (CanUpgrade())
        {
            _viewer.BuildView(_builder.name, _builder.baseIncomeBuild, _upgradeBuild.level, _upgradeBuild.upgradeCost, _informationBuild);
        }
        else
        {
            _viewer.BuildView(_builder.name, _builder.baseIncomeBuild, _builder.costBuilding, _upgradeBuild.level, _upgradeBuild.upgradeCost, _informationBuild);
        }
        
    }
}
