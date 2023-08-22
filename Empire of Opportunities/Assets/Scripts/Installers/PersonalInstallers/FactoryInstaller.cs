using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
   public override void InstallBindings()
    {
        Container.Bind<IFactoryPersonal>().To<FactoryPersonal>().FromNewComponentOnNewGameObject().AsSingle();
    }
}
