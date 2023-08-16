using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonShowManagerUpgrade : MonoBehaviour
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
        PanelShow();
    }

    private void PanelShow()
    {
        panelUpgrade.SetActive(true);
    }
  
}
