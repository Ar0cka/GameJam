using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshpro;
    private int money = 300;
    private string text = "Money";

    private void FixedUpdate()
    {
        money += 2;     
    }

    private void Update()
    {
       textMeshpro.text = text + "" +  money;
    }


}
