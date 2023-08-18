using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ButtonsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IButtonManager>().To<ButtonManager>().FromNewComponentOnNewGameObject().AsSingle();
    }
}
