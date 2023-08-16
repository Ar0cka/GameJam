using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShowExit : MonoBehaviour
{
    [SerializeField] private Button _buttonExit;

    [SerializeField] private GameObject _panelUpgrade;

    private void Start()
    {
        _buttonExit.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ExitWindow();
    }

    private void ExitWindow()
    {
        _panelUpgrade.SetActive(false);
    }
}
