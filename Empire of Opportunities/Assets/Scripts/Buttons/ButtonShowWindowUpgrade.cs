using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonShowWindowUpgrade : MonoBehaviour
{
    [SerializeField] private Button showUpgradeWindow;
    [SerializeField] private GameObject panelUpgrade;

    void Start()
    {
        showUpgradeWindow.onClick.AddListener(OnClick);
        panelUpgrade.SetActive(false);
    }
    private void OnClick()
    {
        if (ButtonManager.Instance != null)
        {
            ButtonManager.Instance.SetActiveButton();
        }
        if (ButtonManager.Instance != null && ButtonManager.Instance.invisible)
        {
            PanelShow();
            showUpgradeWindow.interactable = false;
        }  
        else if (ButtonManager.Instance != null && !ButtonManager.Instance.invisible == false)
        {
            showUpgradeWindow.interactable = true;
        }
    }

    private void PanelShow()
    {
        panelUpgrade.SetActive(true);
    }
  
}
