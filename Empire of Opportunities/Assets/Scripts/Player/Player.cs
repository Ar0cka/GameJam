using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int InitialCapital = 1000;
    private int currentCapital;

    private UIMoneyShow moneyComponent;

    void Start()
    {
        currentCapital = InitialCapital;
        moneyComponent = FindObjectOfType<UIMoneyShow>().GetComponent<UIMoneyShow>();
    }

    public void UpgradeCapital()
    {
        moneyComponent.DisplayingText(currentCapital);
    }
   public void AddToTotalCapital(int amount)
    {
        currentCapital += amount;
    }
}
