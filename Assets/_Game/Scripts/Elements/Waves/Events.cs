using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace AmazingTowerDefenseGame
{
    public static partial class Events
    {
        public static class Wave
        {
            public static UnityEvent OnWaveTimerClicked = new();
            public static UnityEvent OnWaveSpawnerReset = new();
            public static UnityEvent<WaveSpawnerState> OnWaveSpawnerStateChanged = new();
            public static UnityEvent OnNextWaveCooldownTick = new();
            public static UnityEvent OnNextWaveCooldownEnd = new();

        }
    }
}
