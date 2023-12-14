using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame
{
    public class Starter : MonoBehaviour
    {
        Level _level;

        public LevelData data;

        [Inject]
        void Construct(Level level)
        {
            _level = level;
        }

        private void Start()
        {
            _level.Reset(data);
        }
    }
}
