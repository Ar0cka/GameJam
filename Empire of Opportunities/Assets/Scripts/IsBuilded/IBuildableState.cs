using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildableState
{
  bool IsBuildable { get; }

  void SetBuilded();
}
