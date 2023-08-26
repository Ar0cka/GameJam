using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchandiserUpgradeButton : ButtonBuyPersonalAbstract
{
    [SerializeField] private Merchandiser merchandiser;

    private void Start()
    {
        merchandiser.ChangeMerchandiserService();
    }
    private void OnEnable()
    {
        merchandiser.OnServiceChange += HandheldPersonalServiceChange;
    }
    private void OnDestroy()
    {
       merchandiser.OnServiceChange -= HandheldPersonalServiceChange;
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
        merchandiser.UpdatePersonal();
        if (CanUpgrade() && buildableState.IsBuildableDNS)
        {
            _mainPlayer.UpdateCapital(_personalService.upgradeCost);
            merchandiser.ChangeMerchandiserService();

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
