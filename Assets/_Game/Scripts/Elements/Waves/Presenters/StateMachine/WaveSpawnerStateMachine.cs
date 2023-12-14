using AmazingTowerDefenseGame;
using AmazingTowerDefenseGame.Utilities.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTowerDefenseGame.Waves.StateMachine
{
    public class WaveSpawnerStateMachine : StateMachine<WaveSpawnerState>
    {
        public readonly WaitingForStart_WaveSpawnerState.Factory _startStateFactory;
        public readonly WaitingForNextWave_WaveSpawnerState.Factory _waitingForNextWaveStateFactory;

        public readonly WaveSpawnerModel _model;
        public readonly WaveSettings _waveSettings;
        public readonly Wave.Pool _wavePool;
        public readonly AsyncProcessor _asyncProcessor;

        public List<WaveData> WaveDatas { get; private set; }
        public WaveData NextWaveData { get; private set; }

        public WaveSpawnerStateMachine(WaitingForStart_WaveSpawnerState.Factory startStateFactory,
                                       WaitingForNextWave_WaveSpawnerState.Factory waitingForNextWaveStateFactory,

                                       WaveSpawnerModel model,
                                       WaveSettings waveSettings,
                                       Wave.Pool wavePool,
                                       AsyncProcessor asyncProcessor) : base()
        {
            _model = model;
            _waveSettings = waveSettings;
            _wavePool = wavePool;
            _asyncProcessor = asyncProcessor;
            _startStateFactory = startStateFactory;
            _waitingForNextWaveStateFactory = waitingForNextWaveStateFactory;
        }

        public void Setup(List<WaveData> waveDatas)
        {
            WaveDatas = waveDatas;

            NextWaveData = waveDatas[0];

            ChangeState(WaveSpawnerState.WaitingForStart);
        }

        public void ChangeState(WaveSpawnerState newState)
        {
            IState stateObj = default;

            switch (newState)
            {
                case WaveSpawnerState.WaitingForStart:
                    stateObj = _startStateFactory.Create();
                    break;
                case WaveSpawnerState.WaitingForNextWave:
                    stateObj = _waitingForNextWaveStateFactory.Create();
                    break;
                case WaveSpawnerState.WaitingForIntermediateCooldown:
                    break;
                case WaveSpawnerState.AllWavesSpawned:
                    break;
                default:
                    break;
            }

            base.ChangeState(stateObj);
        }

        public override void Tick() => CurrentState?.Tick();
    }
}
