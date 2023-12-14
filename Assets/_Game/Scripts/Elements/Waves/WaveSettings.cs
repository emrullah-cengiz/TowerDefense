using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace AmazingTowerDefenseGame
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(WaveSettings), fileName = nameof(WaveSettings))]
    public class WaveSettings : ScriptableObject
    {
        public int DefaultWaitTimeBeforeWave = 2;
    }
}
