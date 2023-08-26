using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class AbstractUpgradeCost : MonoBehaviour
{
    #region Serialize
    [Header("Buttons")]
    [SerializeField] protected Button _upgradeLevel;
    [Header("Player")]
    [SerializeField] protected MainPlayer _deduct;
    [Header("UI")]
    [SerializeField] protected UIViewManager _viewer;

    [Inject] protected IBuildableState _buildableState;
    [Inject] protected IBuilderService _builderService;

    protected bool canUpgrade;
    #endregion

    #region Protected Methods
    protected void Awake()
    {
        _upgradeLevel.onClick.AddListener(OnClickUpgrade);
    }

    protected void Start()
    {
        canUpgrade = _deduct.currentCapital >= _builderService.upgradeCost;
    }
    protected void HandlerChangeService(IBuilderService builderService)
    {
        _builderService = builderService;
    }
    #endregion
    #region Abstract Methods
    protected abstract void OnClickUpgrade();
    #endregion
}
