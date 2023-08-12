using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshpro;
    private string text = "Money";

    private void Update()
    {
       textMeshpro.text = text + "";
    }


}
