using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmazingTowerDefenseGame
{
    [CreateAssetMenu(menuName = "Level", fileName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public int MaxBuildingLevel;

        public List<WaveData> Waves;
    }

    [CreateAssetMenu(menuName = "Enemy", fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float Speed = 1;
        public short Health = 10;
        public float Armor = 0;
    }

    [Serializable]
    public class WaveData
    {
        public short CoolDownAfterLastWave;

        public List<EnemyWaveData> Enemies;
    }

    [Serializable]
    public class EnemyWaveData
    {
        public Vector2 PreviousEnemyOffset;

        public EnemyData Enemy;
    }
}
