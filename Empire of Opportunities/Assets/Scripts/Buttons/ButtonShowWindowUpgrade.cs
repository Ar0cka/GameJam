using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonShowWindowUpgrade : AbstractClassInButton
{
    private void Update()
    {
        if (CanClick()==false || panelUpgradeBuild.activeSelf == false)
            openUpgradeButton.interactable = true;
        else if(CanClick() || panelUpgradeBuild.activeSelf == true)
            openUpgradeButton.interactable = false;
    }
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
            CloseAllPanel();
        }
    }
    protected override void PanelShow()
    {
        panelUpgradeBuild.SetActive(true);
    }
    protected override void CloseAllPanel()
    {
        panelUpgradePersonal.SetActive(false);
    }
}
