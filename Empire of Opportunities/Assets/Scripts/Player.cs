using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int InitialCapital = 1000;
    private int currentCapital;

    private Money moneyComponent;

    void Start()
    {
        currentCapital = InitialCapital;
        moneyComponent = FindObjectOfType<Money>().GetComponent<Money>();
    }

    public void UpgradeCapital()
    {
        moneyComponent.UpdateMoneyText(currentCapital);
    }
   public void AddToTotalCapital(int amount)
    {
        currentCapital += amount;
    }
}
