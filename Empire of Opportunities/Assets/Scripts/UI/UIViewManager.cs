using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIViewManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyView;

    public void MoneyView(int amount)
    {
        _moneyView.text = "Money: " + amount;
    }

    public void BuildView(string name, int baseIncome, int costBuilding, int level, int upgradeCost, TextMeshProUGUI builderText)
    {
        builderText.text = "Name: " + name + ". \nIncome: " + baseIncome + ". \nCost building: " + costBuilding + ". \nLevel: " + level + ". \nUpgrade cost " + upgradeCost;
    }
    public void BuildView(string name, int baseIncome, int level, int upgradeCost, TextMeshProUGUI builderText)
    {
        builderText.text = "Name: " + name + ". \nIncome: " + baseIncome + ". \nLevel: " + level + ". \nUpgrade cost " + upgradeCost;
    }

    public void SetPersonalText(string name, int income ,int level, int upgradeCost, TextMeshProUGUI Personaltext)
    {
        Personaltext.text ="Name: " + name + ". \nIncome: " + income + "." +
            " \nLevel: " + level + ". \nCost upgrade: " + upgradeCost;
    }
}
