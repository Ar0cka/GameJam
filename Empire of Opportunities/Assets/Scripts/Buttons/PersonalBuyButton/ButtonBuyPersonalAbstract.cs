using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class ButtonBuyPersonalAbstract : MonoBehaviour
{
    [SerializeField] protected Button _buyPersonalButton;

    [SerializeField] protected TextMeshProUGUI _buttonBuyText;

    [SerializeField] protected MainPlayer _mainPlayer;

    [Inject] protected IBuildableState buildableState;
    [Inject] protected IPesonalService _personalService;

    protected void Awake()
    {
        _buyPersonalButton.onClick.AddListener(OnClickBuyPersonal);
    }

    protected bool CanUpgrade()
    {
        return _mainPlayer.currentCapital >= _personalService.upgradeCost;
    }
    protected abstract void OnClickBuyPersonal();
}
