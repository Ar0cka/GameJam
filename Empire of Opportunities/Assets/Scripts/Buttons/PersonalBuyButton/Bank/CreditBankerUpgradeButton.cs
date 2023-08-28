using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBankerUpgradeButton :ButtonBuyPersonalAbstract
{
    [SerializeField] private CreditBanker _creditBanker;

    private void Start()
    {
        _creditBanker.ChangeCreditBankerService();
    }
    private void OnEnable()
    {
        _creditBanker.OnServiceChange += HandheldPersonalServiceChange;
    }
    private void OnDestroy()
    {
        _creditBanker.OnServiceChange -= HandheldPersonalServiceChange;
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
        _creditBanker.UpdatePersonal();
        if (CanUpgrade() && buildableState.IsBuildableBank)
        {
            _mainPlayer.UpdateCapital(_personalService.upgradeCost);
            _creditBanker.ChangeCreditBankerService();

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
