using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableState : MonoBehaviour, IBuildableState
{ 

    private bool _isBuildableShop = false;
    private bool _isBuildableDNS = false;

    public bool IsBuildableShop => _isBuildableShop;
    public bool IsBuildableDNS => _isBuildableDNS;

    public void SetBuilderShop()
    {
        _isBuildableShop = true;
    }
    public void SetBuilderDNS()
    {
        _isBuildableDNS = true;
    }
}
