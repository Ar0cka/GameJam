using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyPersonalButton : MonoBehaviour
{
    [SerializeField] private Button _buyPersonalButton;

    [SerializeField] private TextMeshProUGUI _buttonBuyText;

    [SerializeField] private MainPlayer _mainPlayer;

    [SerializeField] private Salesman _salesman;

    [Inject] private IBuildableState buildableState;
    [Inject] private IPesonalService _personalSalesmanService;

    private float checkInterval = 1.5f;
    private float lastCheck;

    private void Awake()
    {
        _buyPersonalButton.onClick.AddListener(OnClick);
    }

    private void OnEnable()
    {
        _salesman.OnSalesmanServiceChange += HandheldPersonalServiceChange;
    }

    private void OnDestroy()
    {
        _salesman.OnSalesmanServiceChange -= HandheldPersonalServiceChange;
    }

    private void HandheldPersonalServiceChange(IPesonalService newPersonalService)
    {
        _personalSalesmanService = newPersonalService;
    }

    private void Start()
    {
        CheckUpdateCost();
        lastCheck = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastCheck > checkInterval)
        {
            CheckUpdateCost();
            lastCheck = Time.time;
        }
    }
    private void OnClick() 
    {
        if(CanUpgrade())
        {
            _mainPlayer.UpdateCapital(_personalSalesmanService.upgradeCost);
            _salesman.UpgradeCost();
            _salesman.UpgradeTextSalesMan();

            if (_personalSalesmanService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }      
    }

    private void UpgradeUI()
    { 
        _buyPersonalButton.interactable = CanUpgrade();
    }

    private bool CanUpgrade()
    {
        return _mainPlayer.currentCapital >= _personalSalesmanService.upgradeCost && buildableState.IsBuildable;
    }

    private void CheckUpdateCost()
    {
        UpgradeUI();
    }
}
