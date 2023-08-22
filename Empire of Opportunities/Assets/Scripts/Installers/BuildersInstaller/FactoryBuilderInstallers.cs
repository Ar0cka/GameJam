using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FactoryBuilderInstallers : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IFactoryBuild>().To<FactoryBuilder>().AsSingle();
    }
}
