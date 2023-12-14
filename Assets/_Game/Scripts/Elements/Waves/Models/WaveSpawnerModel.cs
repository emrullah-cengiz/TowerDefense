using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace AmazingTowerDefenseGame
{
    public class WaveSpawnerModel
    {
        public bool IsPaused { get; set; }

        public int CurrentWaveIndex { get; set; }

        public int NextWaveStartRemainingCooldown { get; set; }
        public int NextWaveOriginalCooldown { get; set; }

        public int WaveCountOnThisLevel { get; set; }

        public void Reset(int waveCountOnThisLevel)
        {
            IsPaused = true;
            CurrentWaveIndex = 0;
            NextWaveStartRemainingCooldown = 0;
            NextWaveOriginalCooldown = 0;
            WaveCountOnThisLevel = waveCountOnThisLevel;

            Events.Wave.OnWaveSpawnerReset?.Invoke();
        }
    }
}
