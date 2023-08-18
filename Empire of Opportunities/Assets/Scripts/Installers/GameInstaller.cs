using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Complet Zenject");
        Container.Bind<IBuildableState>().To<BuildableState>().FromNewComponentOnNewGameObject().AsSingle();
    }
}
