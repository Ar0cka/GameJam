using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class AbstractClassInButton : MonoBehaviour
{
    [Inject] protected IButtonManager buttonManager;
  

    [Header("Panels")]
    [SerializeField] protected GameObject panelUpgradeBuild;
    [SerializeField] protected GameObject panelUpgradePersonal;

    [Header("Buttons")]
    [SerializeField] protected Button openUpgradeButton;

    protected void Start()
    {
        openUpgradeButton.onClick.AddListener(OnClick);
    }

    protected bool CanClick()
    {
        return buttonManager.invisible;
    }
    protected abstract void OnClick();
    protected abstract void PanelShow();

    protected abstract void CloseAllPanel();

}
