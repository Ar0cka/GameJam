using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonShowUpgradePersonal : MonoBehaviour
{
        [SerializeField] private Button showUpgradeWindowPersonal;
        [SerializeField] private GameObject panelUpgradeBuild;
        [SerializeField] private GameObject panelUpgradePersonal;

        [Inject] private IButtonManager _buttonManager;
        void Start()
        {
            showUpgradeWindowPersonal.onClick.AddListener(OnClick);
            panelUpgradeBuild.SetActive(false);
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
                showUpgradeWindowPersonal.interactable = false;
            }
            else if (_buttonManager != null && !_buttonManager.invisible == false)
            {
                showUpgradeWindowPersonal.interactable = true;
            }
        }

        private void PanelShow()
        {
            panelUpgradeBuild.SetActive(false);
            panelUpgradePersonal.SetActive(true);
        }

}
