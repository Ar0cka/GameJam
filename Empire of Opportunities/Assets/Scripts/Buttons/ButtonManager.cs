using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour, IButtonManager
{
    private static ButtonManager instance;

    public static ButtonManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ButtonManager>();
            }
            return instance;
        }
    }

    private bool _isInvisible = false;
    public bool invisible => _isInvisible;

    public void SetActiveButton()
    {
        _isInvisible = true;
    }
    public void SetDeactivateButton()
    {
        _isInvisible = false;
    }
}
