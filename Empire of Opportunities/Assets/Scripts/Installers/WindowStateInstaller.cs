using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowStateInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IWindowState>().To<WindowOpenState>().AsSingle();
    }
}
