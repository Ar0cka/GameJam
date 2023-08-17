using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgradeLevel : MonoBehaviour
{
    [SerializeField] private Button _upgradeLevel;

    [SerializeField] private StoreShop _shop;

    [SerializeField] private MainPlayer _deduct;

    private void Start()
    {
        _upgradeLevel.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (_deduct.currentCapital >= _shop._isUpdateCost && BuildableState.Instance.IsBuildable) 
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
        if (BuildableState.Instance != null && BuildableState.Instance.IsBuildable)
        {
            if (_deduct.currentCapital >= _shop._isUpdateCost)
            {
                _deduct.UpdateCapital(_shop._isUpdateCost);
                _shop.UpdateLevel();
            }
        }
    }
}
