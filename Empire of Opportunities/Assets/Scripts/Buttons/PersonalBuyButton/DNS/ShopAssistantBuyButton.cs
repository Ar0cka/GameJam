using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAssistantBuyButton : ButtonBuyPersonalAbstract
{
    [SerializeField] private ShopAssistant shopAssistant;

    private void Start()
    {
        shopAssistant.ChangeShopService();
    }
    private void OnEnable()
    {
        shopAssistant.OnServiceChange += HandheldPersonalServiceChange;
    }
    private void OnDestroy()
    {
       shopAssistant.OnServiceChange -= HandheldPersonalServiceChange;
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
        shopAssistant.UpdatePersonal();
        if (CanUpgrade() && buildableState.IsBuildableDNS)
        {
            _mainPlayer.UpdateCapital(_personalService.upgradeCost);
            shopAssistant.ChangeShopService();

            if (_personalService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }
    }


    private void CheckUpdateCost()
    {
        _buyPersonalButton.interactable = CanUpgrade() && buildableState.IsBuildableDNS;
    }
}
