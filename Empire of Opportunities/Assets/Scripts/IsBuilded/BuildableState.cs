using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableState : MonoBehaviour, IBuildableState
{
    //private static BuildableState _instance;
    //public static BuildableState Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = FindObjectOfType<BuildableState>();
    //        }
    //        return _instance;
    //    }
    //}

    private bool _isBuildable = false;

    public bool IsBuildable => _isBuildable;

    public void SetBuilded()
    {
        _isBuildable = true;
    }
}
