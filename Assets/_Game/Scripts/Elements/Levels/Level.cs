using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame
{
    public class Level 
    {
        public LevelData Data { get; private set; }

        public readonly WaveSpawner _waveSpawner;

        public Level(WaveSpawner waveSpawner)
        {
            Debug.Log("Level created");

            _waveSpawner = waveSpawner;
        }

        public void Reset(LevelData data)
        {
            Data = data;

            _waveSpawner.Setup(Data.Waves);
        }
    }
}