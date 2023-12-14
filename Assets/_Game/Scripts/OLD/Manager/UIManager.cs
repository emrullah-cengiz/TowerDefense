using Assets._Game.Scripts.Abstracts;
using Assets._Game.Scripts.Enums;
using Assets._Game.Scripts.Extensions;
using Assets._Game.Scripts.Signals;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class UIManager : MyObject<UIManager>
    {
        //[SerializeField] private HashSet<InGameMenuType, GameObject>

        protected override void ConfigureSubscriptions(bool status)
        {
            UISignals.OnInGameMenuOpened.Subscribe(OpenInGameMenu, status);
        }

        private void OpenInGameMenu(InGameMenuType menuType)
        {
            
        }
    }
}