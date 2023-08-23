using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonControllerShopStore : MonoBehaviour
{ 
    [Header("Shop")]
    [SerializeField] private StoreShop shop;
    [Header("Player")]
    [SerializeField] private MainPlayer mainPlayer;
    [Header("UI")]
    [SerializeField] private UIViewManager _viewer;
    [SerializeField] private Button buyButton;
    [SerializeField] private Contract contract;

    [Inject] private IBuilderService _builderService;
    [Inject] private IBuildableState _buildableState;

    private void Awake()
    {
        buyButton.onClick.AddListener(OnClick);
    }
  
    private void Start()
    {
        buyButton.gameObject.SetActive(false);
        shop.ChangeBuildService();
    }
    private void OnEnable()
    {
        shop.OnChangeBuilderService += HandheldBuildServiceChange;
    }
    private void OnDisable()
    {
        shop.OnChangeBuilderService -= HandheldBuildServiceChange;
    }
    private void HandheldBuildServiceChange(IBuilderService builderService)
    {
        _builderService = builderService;
    }
    private void OnClick()
    {
        if (_buildableState != null)
        {
            _buildableState.SetBuilded();
        }
        if (CanUpgrade())
        {
            mainPlayer.Build(_builderService.costBuilding);

            if (contract != null)
            {
                contract.gameObject.SetActive(true);
                contract.StartDisplay();
            }

            shop.ChangeUIBuilder();

            Purchase();
        } 
    }
    private bool CanUpgrade()
    {
        return _buildableState != null && _buildableState.IsBuildable;
    }

    private void Purchase()
    {
        buyButton.gameObject.SetActive(false);
    }
}
