using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIViewManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyView;

    [SerializeField] private TextMeshProUGUI _costView;

    [SerializeField] private TextMeshProUGUI _incomeView;

    [SerializeField] private TextMeshProUGUI _levelView;

    public void MoneyView(int amount)
    {
        _moneyView.text = "Money: " + amount;
    }

    public void CostView(int amount)
    {
        _costView.text = "Cost: " + amount;
    }

    public void IncomeView(int amount)
    {
        _incomeView.text = "Income: " + amount;
    }

    public void LevelView(int amount)
    {
        _levelView.text = "Level: " + amount;
    }
}
