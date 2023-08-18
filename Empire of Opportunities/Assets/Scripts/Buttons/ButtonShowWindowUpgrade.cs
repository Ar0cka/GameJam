using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonShowWindowUpgrade : MonoBehaviour
{
    [SerializeField] private Button showUpgradeWindow;
    [SerializeField] private GameObject panelUpgrade;

    [Inject] private IButtonManager _buttonManager;
    void Start()
    {
        showUpgradeWindow.onClick.AddListener(OnClick);
        panelUpgrade.SetActive(false);
    }
    private void OnClick()
    {
        if (_buttonManager != null)
        {
            _buttonManager.SetActiveButton();
        }
        if (_buttonManager != null && _buttonManager.invisible)
        {
            PanelShow();
            showUpgradeWindow.interactable = false;
        }  
        else if (_buttonManager != null && !_buttonManager.invisible == false)
        {
            showUpgradeWindow.interactable = true;
        }
    }

    private void PanelShow()
    {
        panelUpgrade.SetActive(true);
    }
  
}
