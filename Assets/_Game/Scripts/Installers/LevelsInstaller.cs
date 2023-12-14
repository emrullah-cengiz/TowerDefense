using AmazingTowerDefenseGame;
using System.Reflection.Emit;
using UnityEngine;
using Zenject;

public class LevelsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Level>().AsSingle();
    }
}