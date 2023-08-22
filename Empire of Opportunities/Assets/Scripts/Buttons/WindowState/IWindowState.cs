using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindowState 
{
    void Open();
    void Close();

    bool IsOpen {  get; }
}
