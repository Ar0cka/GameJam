using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuySalesManButton : ButtonBuyPersonalAbstract
{
    [SerializeField] private Salesman _salesman;

    private void Start()
    {
        _salesman.ChangeShopService();
    }

    private void OnEnable()
    {
        _salesman.OnServiceChange += HandheldPersonalServiceChange;
    }

    private void OnDestroy()
    {
        _salesman.OnServiceChange -= HandheldPersonalServiceChange;
   
    }

    private void HandheldPersonalServiceChange(IPesonalService newPersonalService)
    {
        _personalService = newPersonalService;
    }

    private void Update()
    {
        UpgradeUI();
    }
    protected override void OnClickBuyPersonal() 
    {
        _salesman.UpdatePersonal();
        if (CanUpgrade() && buildableState.IsBuildableShop)
        {
            _mainPlayer.UpdateCapital(_personalService.upgradeCost);
            _salesman.ChangeShopService();

            if (_personalService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }      
    }

    private void UpgradeUI()
    {
        _buyPersonalButton.interactable = CanUpgrade() && buildableState.IsBuildableShop;
    }

}
