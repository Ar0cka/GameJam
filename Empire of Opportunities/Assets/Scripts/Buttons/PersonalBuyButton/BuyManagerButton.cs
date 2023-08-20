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

    private float checkInterval = 1.5f;
    private float lastCheck;

    private void Awake()
    {
        _buyManagerButton.onClick.AddListener(OnClick);
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
        if (CanUpgrade())
        {
            _mainPlayer.UpdateCapital(_personalManagerService.upgradeCost);

            UpgradePersonalCost();

            _manager.UpdateManagerUI();

            if (_personalManagerService.level > 0)
            {
                _buttonBuyText.text = "Upgrade";
            }
        }
    }
    private bool CanUpgrade()
    {
        return _mainPlayer.currentCapital >= _personalManagerService.upgradeCost && buildableState.IsBuildable;
    }
    private void UpgradePersonalCost()
    {
        _manager.UpdateCost();
    }

    private void CheckUpdateCost()
    {
        _buyManagerButton.interactable = CanUpgrade();
    }
}
