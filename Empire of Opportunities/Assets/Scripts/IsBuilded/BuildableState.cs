using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableState : MonoBehaviour, IBuildableState
{ 

    private bool _isBuildable = false;

    public bool IsBuildable => _isBuildable;

    public void SetBuilded()
    {
        _isBuildable = true;
    }
}
