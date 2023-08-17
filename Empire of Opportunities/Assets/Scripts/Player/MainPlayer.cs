using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    private int InitialCapital = 1000;
    public int currentCapital;

    private UIMoneyShow moneyComponent;

    private void Start()
    {
        currentCapital = InitialCapital;
        moneyComponent = FindObjectOfType<UIMoneyShow>().GetComponent<UIMoneyShow>();
    }
    private void Update()
    {
        moneyComponent.DisplayingText(currentCapital);
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
    }
}
