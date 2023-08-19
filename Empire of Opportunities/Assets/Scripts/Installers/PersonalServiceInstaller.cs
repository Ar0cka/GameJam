using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class PersonalServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPesonalService>().To<PersonalService>().AsSingle();
    }
}
