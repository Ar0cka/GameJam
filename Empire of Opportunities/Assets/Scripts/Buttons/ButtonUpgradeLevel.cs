using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonUpgradeLevel : MonoBehaviour
{
    [SerializeField] private Button _upgradeLevel;

    [SerializeField] private StoreShop _shop;

    [SerializeField] private MainPlayer _deduct;

    [SerializeField] private UIViewManager _viewer;

    [Inject] private IBuildableState _buildableState;

    private void Start()
    {
        _upgradeLevel.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (_deduct.currentCapital >= _shop.UpdateCost && _buildableState.IsBuildable) 
        {
            _upgradeLevel.interactable = true;
        }
        else
        {
            _upgradeLevel.interactable = false;
        }

    }

    private void OnClick()
    {
        if (_buildableState != null && _buildableState.IsBuildable)
        {
            if (_deduct.currentCapital >= _shop.UpdateCost)
            {
                _deduct.UpdateCapital(_shop.UpdateCost);
                _shop.UpdateLevel();
            }
            _viewer.CostView(_shop.UpdateCost);
            _viewer.IncomeView(_shop.InitialIncome);
        }
    }
}
