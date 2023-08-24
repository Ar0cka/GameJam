using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    private BuilderType typeBuild;
    [Header("UI")]
    [SerializeField] private UIViewManager _viewManager;
    [SerializeField] private TextMeshProUGUI _incomePlayerInformation;
    [SerializeField] private TextMeshProUGUI _moneyView;

    private int InitialCapital = 1000;
    public int currentCapital;

    private void Start()
    {
        currentCapital = InitialCapital;
    }
    private void Update()
    {
       _viewManager.MoneyView(currentCapital, _moneyView);
    }
    public void UpdateCapital(int deductCapital)
    {
            currentCapital -= deductCapital;    
    }
    public void Build(int costBuild)
    {
        currentCapital -= costBuild;
    }
    public void AddToTotalCapital(int amount)
    {
        currentCapital += amount;
        _viewManager.SetMoneyIncome(amount, _incomePlayerInformation);
    }
    
}
