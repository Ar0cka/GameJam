using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class BuilderServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
      Container.Bind<IBuilderService>().To<BuilderService>().AsSingle();
    }
}
