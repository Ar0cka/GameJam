using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShowPersonalWindow : AbstractClassInButton
{
    protected override void OnClick()
    {
        if (buttonManager != null) { buttonManager.SetActiveButton(); }

        bool canClick = CanClick();
        if (canClick)
        {
            PanelShow();
            openUpgradeButton.interactable = true;
            CloseAllPanel();
        }
        else if (canClick == false)
        {
            openUpgradeButton.interactable = false;
        }
    }
    protected override void PanelShow()
    {
        _windowState.Open();
        panelUpgradePersonal.SetActive(_windowState.IsOpen);
    }
    protected override void CloseAllPanel()
    {
        _windowState.Close();
        panelUpgradeBuild.SetActive(_windowState.IsOpen);
    }
}
