using AmazingTowerDefenseGame.Utilities.StateMachine;
using AmazingTowerDefenseGame.Waves.StateMachine;
using Assets._Game.Scripts.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame
{
    public enum WaveSpawnerState
    {
        WaitingForStart,
        WaitingForNextWave,
        WaitingForIntermediateCooldown,
        AllWavesSpawned
    }

    public class WaveSpawner : IInitializable, IDisposable
    {
        private WaveSpawnerState _currentState;
        public WaveSpawnerState CurrentState
        {
            get => _currentState;
            private set
            {
                _currentState = value;

                Events.Wave.OnWaveSpawnerStateChanged?.Invoke(value);
            }
        }

        public List<WaveData> WaveDatas { get; private set; }

        private readonly WaveSettings _waveSettings;
        private readonly Wave.Pool _wavePool;

        private readonly WaveSpawnerModel _model;
        private readonly WaveSpawnerView _view;

        private readonly WaveSpawnerStateMachine _stateMachine;
        private readonly AsyncProcessor _asyncProcessor;

        public WaveSpawner(WaveSpawnerModel model,
                           WaveSpawnerView view,
                           WaveSettings waveSettings,
                           Wave.Pool wavePool,
                           AsyncProcessor asyncProcessor,
                           WaveSpawnerStateMachine stateMachine)
        {
            Debug.Log("WaveSpawner created");

            _model = model;
            _view = view;

            _waveSettings = waveSettings;
            _wavePool = wavePool;

            _asyncProcessor = asyncProcessor;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            //Events.Wave.OnWaveTimerClicked.Subscribe(StartWaveMachine, true);

            //CurrentState = WaveSpawnerState.WaitingForStart;
        }

        public void Setup(List<WaveData> waveDatas)
        {
            WaveDatas = waveDatas;

            _stateMachine.Setup(waveDatas);

            _model.Reset(WaveDatas.Count);

        }

        public void Dispose()
        {
            //Events.Wave.OnWaveTimerClicked.Subscribe(StartWaveMachine, false);
        }

    }
}

