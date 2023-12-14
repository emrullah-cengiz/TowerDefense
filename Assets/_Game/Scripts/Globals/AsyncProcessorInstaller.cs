using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame
{
    public class GlobalHelpersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AsyncProcessor>()
                     .FromNewComponentOnNewGameObject()
                     .AsSingle();
        }
    }

    public class AsyncProcessor : MonoBehaviour
    {
        // Purposely left empty
    }

}
