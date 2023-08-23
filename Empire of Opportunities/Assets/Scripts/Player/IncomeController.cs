using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncomeController : MonoBehaviour
{
    public static IncomeController instance;

    private MainPlayer player;

    private int IncomeCapital;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        player = GetComponent<MainPlayer>();
    }

    private void Start()
    {
        InvokeRepeating("AddToCapitalPlayer", 0, 1.5f);
    }

    public void IncreaseCapital(int amount)
    {
        IncomeCapital += amount;
    }

    private void AddToCapitalPlayer()
    {
        player.AddToTotalCapital(IncomeCapital);
        IncomeCapital = 0;
    }
}
