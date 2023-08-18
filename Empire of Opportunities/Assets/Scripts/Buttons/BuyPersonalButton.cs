using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyPersonalButton : MonoBehaviour
{
    [SerializeField] private Button _buyPersonalButton;

    [SerializeField] private MainPlayer _mainPlayer;

    [SerializeField] private Salesman _salesman;

    [Inject] private IBuildableState buildableState;

    private float checkInterval = 2f;
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
        if (_mainPlayer.currentCapital >= _salesman.updateCost && buildableState.IsBuildable)
        {
            _mainPlayer.UpdateCapital(_salesman.updateCost);
        }
    }
    
    private void CheckUpdateCost()
    {
        if (_mainPlayer.currentCapital >= _salesman.updateCost && buildableState.IsBuildable)
        {
            _buyPersonalButton.interactable = true;
        }
        else
        {
            _buyPersonalButton.interactable = false;
        }
    }
}
