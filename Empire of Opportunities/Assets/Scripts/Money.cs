using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshpro;
  
    public void UpdateMoneyText(int amount)
    {
        textMeshpro.text = "Money: " + amount.ToString();
    }
}
