using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyManagerButton : MonoBehaviour
{
    [SerializeField] private Button _buyManagerButton;

    [SerializeField] private TextMeshProUGUI _buttonBuyText;

    [SerializeField] private MainPlayer _mainPlayer;

    [SerializeField] private Manager _manager;

    [Inject] private IBuildableState buildableState;
    [Inject] private IPesonalService _personalManagerService;

    private void Awake()
    {
        _buyManagerButton.onClick.AddListener(OnClick);
    }
    private void Start()
    {
        _manager.UpdateCostService();
    }
    private void OnEnable()
    {
        _manager.OnPersonalServiceChange += HandheldPersonalServiceChange;
    }
    private void OnDestroy()
    {
        _manager.OnPersonalServiceChange -= HandheldPersonalServiceChange;
    }

    private void HandheldPersonalServiceChange(IPesonalService newPersonalService)
    {
        _personalManagerService = newPersonalService;
    }

    private void Update()
    {
        CheckUpdateCost();
    }
    private void OnClick()
    {
        _manager.UpdateCost();
        if (CanUpgrade())
        {
            _mainPlayer.UpdateCapital(_personalManagerService.upgradeCost);
            _manager.UpdateCostService();
            _manager.UpdateManagerUI();

            if (_personalManagerService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }
    }
    private bool CanUpgrade()
    {
        return _mainPlayer.currentCapital >= _personalManagerService.upgradeCost && buildableState.IsBuildableShop;
    }

    private void CheckUpdateCost()
    {
        _buyManagerButton.interactable = CanUpgrade();
    }
}
