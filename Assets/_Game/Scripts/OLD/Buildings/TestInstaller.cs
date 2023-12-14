using AmazingTowerDefenseGame.Infrastructure;
using Assets._Game.Scripts.Abstracts;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Zenject.SpaceFighter;

namespace Game
{

    public class TestInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ATDMonoObject>().AsTransient();

            Container.Bind<BuildingPlace>().FromComponentInHierarchy().AsTransient();
        }
    }

}