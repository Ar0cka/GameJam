using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DoBuild : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private Sprite _newSprite;

    private SpriteRenderer _spriteRenderer;

    private bool _isSelected = false;
    private bool _isBuilded = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if(_isBuilded == false)
        {
            _buyButton.onClick.AddListener(TryChangeSprite);
            _buyButton.gameObject.SetActive(true);
            _buyButton.transform.position = this.transform.position;
            _isSelected = true;
        }    
    }

    private void OnMouseExit()
    {
        if (_isBuilded == false)
        {
            _buyButton.gameObject.SetActive(false);
            _isSelected = false;
        }
        _buyButton.onClick.RemoveListener(TryChangeSprite);
    }

    public void TryChangeSprite()
    {
        if (_isSelected == true)
        {
            _spriteRenderer.sprite = _newSprite;
            _isBuilded = true;
            _buyButton.gameObject.SetActive(false);
        }
    }
}
