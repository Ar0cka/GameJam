using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShowExit : MonoBehaviour
{
    [SerializeField] private Button _buttonExit;

    [SerializeField] private Button _buttonEnter;

    [SerializeField] private GameObject _panelUpgrade;

    private void Start()
    {
        _buttonExit.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (ButtonManager.Instance != null && ButtonManager.Instance.invisible)
        {
            ButtonManager.Instance.SetDeactivateButton();
        }
        if (ButtonManager.Instance.invisible == false)
        {
            ExitWindow();
            _buttonEnter.interactable = true;
        }  
    }

    private void ExitWindow()
    {
        _panelUpgrade.SetActive(false);
    }
}
