using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteAfterBuild : MonoBehaviour
{
    [SerializeField] private Sprite _newSprite;

    private DoBuild _currentBuild;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _currentBuild = GetComponent<DoBuild>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TryChangeSprite()
    {
        if(_currentBuild.IsSelected == true)
        {
            _currentBuild.SetBuild(true);
            _spriteRenderer.sprite = _newSprite;
        }
    }
}
