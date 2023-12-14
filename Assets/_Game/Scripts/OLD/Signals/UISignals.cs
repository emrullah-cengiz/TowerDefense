using Assets._Game.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Signals
{
    public static class UISignals
    {
        public static UnityEvent<InGameMenuType> OnInGameMenuOpened;
    }
}
