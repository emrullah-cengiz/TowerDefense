using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace AmazingTowerDefenseGame.Infrastructure
{
    public class ATDMonoObject : MonoBehaviour, IInitializable, IDisposable
    {
        public void Initialize()
        {
            ConfigureSubscriptions(true);
        }

        public void Dispose()
        {
            ConfigureSubscriptions(false);
        }

        protected virtual void ConfigureSubscriptions(bool status) { }
    }

    public abstract class ATDObject : IInitializable, IDisposable
    {
        public void Initialize()
        {
            ConfigureSubscriptions(true);
        }

        public void Dispose()
        {
            ConfigureSubscriptions(false);
        }

        protected virtual void ConfigureSubscriptions(bool status) { }
    }

}
