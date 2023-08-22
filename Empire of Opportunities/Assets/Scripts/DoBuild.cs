using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoBuild : MonoBehaviour
{
    [SerializeField] private GameObject _buyButton;

    private bool _isSelected = false;
    private bool _isBuilded = false;

    public bool IsSelected => _isSelected;

    private void OnMouseEnter()
    {
        if(_isBuilded == false)
        {
            _buyButton.SetActive(true);
            _buyButton.transform.position = this.transform.position;
            _isSelected = true;
        }    
    }

    private void OnMouseExit()
    {
        if (_isBuilded == false)
        {
            _buyButton.SetActive(false);
            _isSelected = false;
        }
    }

    public void SetBuild(bool currentState)
    {
        _isBuilded = currentState;
    }
}
