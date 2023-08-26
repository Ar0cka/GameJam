using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyManagerButton : ButtonBuyPersonalAbstract
{
    [SerializeField] private Manager _manager;

    private void Start()
    {
        _manager.ChangeDNSService();
    }
    private void OnEnable()
    {
        _manager.OnServiceChange += HandheldPersonalServiceChange;
    }
    private void OnDestroy()
    {
        _manager.OnServiceChange -= HandheldPersonalServiceChange;
    }

    private void HandheldPersonalServiceChange(IPesonalService newPersonalService)
    {
        _personalService = newPersonalService;
    }

    private void Update()
    {
        CheckUpdateCost();
    }
    protected override void OnClickBuyPersonal()
    {
        _manager.UpdatePersonal();
        if (CanUpgrade() && buildableState.IsBuildableShop)
        {
            _mainPlayer.UpdateCapital(_personalService.upgradeCost);
            _manager.ChangeDNSService();

            if (_personalService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }
    }
 

    private void CheckUpdateCost()
    {
        _buyPersonalButton.interactable = CanUpgrade() && buildableState.IsBuildableShop;
    }
}
