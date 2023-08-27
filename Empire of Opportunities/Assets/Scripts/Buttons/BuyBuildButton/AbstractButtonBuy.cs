using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class AbstractButtonBuy : MonoBehaviour
{
    #region Serialize

    [Header("Player")]
    [SerializeField] protected MainPlayer mainPlayer;
    [Header("UI")]
    [SerializeField] protected UIViewManager _viewer;
    [SerializeField] protected Button buyButton;
    [SerializeField] protected Contract contract;

    [Inject] protected IBuilderService _builderService;
    [Inject] protected IBuildableState _buildableState;

    protected bool canBuild;
    #endregion

    private void Start()
    {
        canBuild = _buildableState != null;
    }

    #region Abstract Method
    protected abstract void Awake();
    protected abstract void OnClick();
    protected abstract void BuildingTypeSelected();
    protected abstract void CheckBuildableState();
    #endregion
    #region Protected Method
    //protected void InitializeBuildingTypeSelection()
    //{
    //    buildType = setType.SelectedType();
    //    Debug.Log("Type build abstract"  + buildType);
    //    BuildingTypeSelected(buildType);
    //}
    protected void Contract()
    {
        if (contract != null)
        {
            contract.gameObject.SetActive(true);
            contract.StartDisplay();
        }
    }
    protected void Purchase()
    {
        buyButton.gameObject.SetActive(false);
    }
    #endregion
}
