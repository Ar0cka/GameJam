using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtonManager
{
  bool invisible { get; }

    void SetActiveButton();
    void SetDeactivateButton();
}
