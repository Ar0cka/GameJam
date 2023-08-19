using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasePersonal
{
    string Name { get; }

    int BaseIncome { get; }

    void UpdateBaseIncome(int amount);

}
