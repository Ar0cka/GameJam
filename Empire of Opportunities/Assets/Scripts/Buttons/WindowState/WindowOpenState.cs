using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpenState : IWindowState
{
    private bool _isOpen;

    public bool IsOpen => _isOpen;

    public void Open() { _isOpen = true; }
    public void Close() { _isOpen = false;}
}
