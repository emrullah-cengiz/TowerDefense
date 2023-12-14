using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame
{
    public class Wave
    {
        public WaveData Data { get; private set; }

        public void Reset(WaveData data)
        {
            Data = data;

            Debug.Log("Wave Reinitialized.. | cooldown data: " + Data.CoolDownAfterLastWave);
        }

        public class Pool : MemoryPool<WaveData, Wave>
        {
            protected override void Reinitialize(WaveData data, Wave wave)
            {
                wave.Reset(data);
            }
        }
    }
}
