using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class TileShow : MonoBehaviour
{
   [SerializeField]private TextMeshProUGUI m_TextMeshProUGUI;

    private bool mouseOver;

    private void OnMouseEnter()
    {
        mouseOver = true;
        m_TextMeshProUGUI.enabled = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        m_TextMeshProUGUI.enabled = false;
    }

    private void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Click");
        }
    }

}
