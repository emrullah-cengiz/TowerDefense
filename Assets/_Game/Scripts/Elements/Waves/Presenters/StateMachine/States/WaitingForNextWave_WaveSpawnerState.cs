using AmazingTowerDefenseGame.Utilities.StateMachine;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame.Waves.StateMachine
{
    public class WaitingForNextWave_WaveSpawnerState : State<WaveSpawnerStateMachine, WaveSpawnerState>
    {
        private readonly WaveSpawnerModel _model;

        private readonly Wave.Pool _wavePool;
        private readonly AsyncProcessor _asyncProcessor;

        float elapsedTime = 0;

        public WaitingForNextWave_WaveSpawnerState(WaveSpawnerStateMachine stateMachine,
                                                   WaveSpawnerModel model,
                                                   AsyncProcessor asyncProcessor,
                                                   Wave.Pool wavePool) : base(stateMachine)
        {
            _model = model;
            _asyncProcessor = asyncProcessor;
            _wavePool = wavePool;
        }

        public override void Start()
        {
            _model.NextWaveOriginalCooldown = StateMachine.NextWaveData.CoolDownAfterLastWave;

            _asyncProcessor.StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            for (int i = _model.NextWaveOriginalCooldown - 1; i >= 0; i--)
            {
                _model.NextWaveStartRemainingCooldown = i;

                Events.Wave.OnNextWaveCooldownTick?.Invoke();

                yield return new WaitForSeconds(1);
            }

            Events.Wave.OnNextWaveCooldownEnd?.Invoke();
            Debug.Log("Next Wave called..");

            _wavePool.Spawn(StateMachine.NextWaveData);
        }

        public override void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<WaitingForNextWave_WaveSpawnerState>
        {

        }
    }
}
