using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonShowExit : MonoBehaviour
{
    [SerializeField] private Button _buttonExit;

    [SerializeField] private Button _buttonEnter;

    [SerializeField] private GameObject _panelUpgrade;

    [Inject] private IButtonManager _buttonManager;
    private void Start()
    {
        _buttonExit.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_buttonManager != null && _buttonManager.invisible)
        {
            _buttonManager.SetDeactivateButton();
        }
        if (_buttonManager.invisible == false)
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
