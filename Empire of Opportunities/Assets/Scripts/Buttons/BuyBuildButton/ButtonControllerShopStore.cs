using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Net;

public class ButtonControllerShopStore : MonoBehaviour
{ 
    [Header("Shop")]
    [SerializeField] private StoreShop shop;
    [SerializeField] private DNSControllerBuild dns;
    private SetType setType;
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
        setType = FindObjectOfType<SetType>().GetComponent<SetType>();
        Debug.Log(setType.ToString());
        buyButton.gameObject.SetActive(false);
    }
    private void OnEnableService()
    {
        if (_buildableState.IsBuildableShop)
            shop.OnChangeBuilderService += HandheldBuildServiceChange;
        else if (_buildableState.IsBuildableDNS)
            dns.OnChangeBuilderService += HandheldBuildServiceChange;
    }
    private void OnDisableService()
    {
        if (_buildableState.IsBuildableShop)
            shop.OnChangeBuilderService -= HandheldBuildServiceChange;
        else if (_buildableState.IsBuildableDNS)
            dns.OnChangeBuilderService -= HandheldBuildServiceChange;

    }
    private void HandheldBuildingTypeSelected(BuilderType builderType)
    {

        if (builderType == BuilderType.DNS)
        { 
            _buildableState.SetBuilderDNS();
            dns.ChangeBuildService();

        }
        else if (builderType == BuilderType.Shop)
        {
            _buildableState.SetBuilderShop();
            shop.ChangeBuildService();
        }
    }
    private void HandheldBuildServiceChange(IBuilderService builderService)
    {
        _builderService = builderService;
    }
    private void OnClick()
    {
        InitializeBuildingTypeSelection();
        if (CanUpgrade())
        {
            mainPlayer.Build(_builderService.costBuilding);

            CheckBuildableState();

            Contract();

            Purchase();

            OnDisableService();
        } 
    }
    private bool CanUpgrade()
    {
        return _buildableState != null;
    }

    private void Purchase()
    {
        buyButton.gameObject.SetActive(false);
        setType.OnBuildingTypeSelected -= HandheldBuildingTypeSelected;
    }
    private void InitializeBuildingTypeSelection()
    {
        setType.OnBuildingTypeSelected += HandheldBuildingTypeSelected;
        setType.BuildTypeSelected();
        OnEnableService();
    }
    private void Contract()
    {
        if (contract != null)
        {
            contract.gameObject.SetActive(true);
            contract.StartDisplay();
        }
    }
    private void CheckBuildableState()
    {
        if (_buildableState.IsBuildableDNS)
        {
            dns.ChangeUIBuilder();
        }
        else if (_buildableState.IsBuildableShop)
        {
            shop.ChangeUIBuilder();
        }
    }
}
