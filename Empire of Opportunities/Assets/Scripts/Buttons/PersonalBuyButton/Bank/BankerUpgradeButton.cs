using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankerUpgradeButton : ButtonBuyPersonalAbstract
{
    [SerializeField] private Banker _banker;

    private void Start()
    {
        _banker.ChangeBankService();
    }
    private void OnEnable()
    {
        _banker.OnServiceChange += HandheldPersonalServiceChange;
    }
    private void OnDestroy()
    {
        _banker.OnServiceChange -= HandheldPersonalServiceChange;
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
        _banker.UpdatePersonal();
        if (CanUpgrade() && buildableState.IsBuildableBank)
        {
            _mainPlayer.UpdateCapital(_personalService.upgradeCost);
            _banker.ChangeBankService();

            if (_personalService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }
    }


    private void CheckUpdateCost()
    {
        _buyPersonalButton.interactable = CanUpgrade() && buildableState.IsBuildableBank;
    }
}
