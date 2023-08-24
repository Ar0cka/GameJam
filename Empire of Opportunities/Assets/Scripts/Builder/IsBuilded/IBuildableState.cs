using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildableState
{
  bool IsBuildableShop { get; }
  bool IsBuildableDNS { get; }

  void SetBuilderShop();
  void SetBuilderDNS();
}
