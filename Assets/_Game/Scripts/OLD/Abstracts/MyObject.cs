using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Game.Scripts.Abstracts
{
    [DefaultExecutionOrder(-3)]
    public abstract class MyObject<T> : MonoBehaviour where T : Component
    {
        protected virtual void OnEnable()
        {
            ConfigureSubscriptions(true);
        }

        protected virtual void OnDisable()
        {
            ConfigureSubscriptions(false);
        }

        protected virtual void ConfigureSubscriptions(bool status) { }
    }
}
