using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShowPersonalWindow : AbstractClassInButton
{
    private void Update()
    {
        if (CanClick() == false || panelUpgradePersonal.activeSelf == false)
            openUpgradeButton.interactable = true;
        else if (CanClick() || panelUpgradePersonal.activeSelf == true)
            openUpgradeButton.interactable = false;
    }
    protected override void OnClick()
    {
        if (buttonManager != null) { buttonManager.SetActiveButton(); }

        bool canClick = CanClick();
        if (canClick)
        {
            PanelShow();
            openUpgradeButton.interactable = false;
            CloseAllPanel();
        }
        else if (canClick == false)
        {
            openUpgradeButton.interactable = true;
        }
    }
    protected override void PanelShow()
    {
        panelUpgradePersonal.SetActive(true);
    }
    protected override void CloseAllPanel()
    {
        panelUpgradeBuild.SetActive(false);
    }
}
