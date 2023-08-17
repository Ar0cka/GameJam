using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    private int InitialCapital = 1000;
    public int currentCapital;

    private UIViewManager moneyComponent;

    private void Start()
    {
        currentCapital = InitialCapital;
        moneyComponent = FindObjectOfType<UIViewManager>().GetComponent<UIViewManager>();
    }
    private void Update()
    {
        moneyComponent.MoneyView(currentCapital);
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
