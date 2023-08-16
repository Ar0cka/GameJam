using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoneyShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshpro;
  
    public void DisplayingText(int amount)
    {
        UpdateMoneyText(amount);
    }
    private void UpdateMoneyText(int amount)
    {
        textMeshpro.text = "Money: " + amount;
    }
}
