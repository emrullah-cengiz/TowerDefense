using Assets._Game.Scripts.Abstracts;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;
using AmazingTowerDefenseGame.Infrastructure;

namespace Game
{

    public class BuildingPlace : ATDMonoObject
    {
        protected override void ConfigureSubscriptions(bool status)
        {
            print(status);
        }
    }

    public interface IATDMonoObject : IInitializable, IDisposable
    {
        protected virtual void ConfigureSubscriptions(bool status) { }

        void IInitializable.Initialize()
        {
            ConfigureSubscriptions(true);
        }

        void IDisposable.Dispose()
        {
            ConfigureSubscriptions(false);
        }
    }

}