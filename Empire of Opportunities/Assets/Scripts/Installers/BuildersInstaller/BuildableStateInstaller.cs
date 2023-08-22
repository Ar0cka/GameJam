using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildableStateInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBuildableState>().To<BuildableState>().FromNewComponentOnNewGameObject().AsSingle();
    }
}
