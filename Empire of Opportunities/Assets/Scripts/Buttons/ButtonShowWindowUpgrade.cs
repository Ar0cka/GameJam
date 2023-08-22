using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonShowWindowUpgrade : AbstractClassInButton
{
    protected override void OnClick()
    {
        if (buttonManager != null)
        {
            buttonManager.SetActiveButton();
        }
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
        _windowState.Open();
        panelUpgradeBuild.SetActive(_windowState.IsOpen);
    }
    protected override void CloseAllPanel()
    {
        _windowState.Close();
        panelUpgradePersonal.SetActive(_windowState.IsOpen);
    }
}
