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
    [Inject] private IPesonalService _personalService;

    private float checkInterval = 1.5f;
    private float lastCheck;
    private void Start()
    {
        _buyPersonalButton.onClick.AddListener(OnClick);
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
        if (_mainPlayer.currentCapital >= _personalService.upgradeCost && buildableState.IsBuildable)
        {
            _buttonBuyText.text = "Upgrade";

            _mainPlayer.UpdateCapital(_personalService.upgradeCost);

            UpgradePersonalCost();

            _salesman.UpgradeTextMeshPro();
        }
    }

    private void UpgradePersonalCost()
    {
        _salesman.UpgradeCost();
    }

    private void CheckUpdateCost()
    {
        if (_mainPlayer.currentCapital >= _personalService.upgradeCost && buildableState.IsBuildable)
        {
            _buyPersonalButton.interactable = true;
        }
        else
        {
            _buyPersonalButton.interactable = false;
        }
    }
}
