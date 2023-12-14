using AmazingTowerDefenseGame.Utilities.StateMachine;
using Assets._Game.Scripts.Extensions;
using Zenject;

namespace AmazingTowerDefenseGame.Waves.StateMachine
{
    public class WaitingForStart_WaveSpawnerState : State<WaveSpawnerStateMachine, WaveSpawnerState>
    {
        public WaitingForStart_WaveSpawnerState(WaveSpawnerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Start()
        {
            Events.Wave.OnWaveTimerClicked.Subscribe(StartTimer, true);
        }

        private void StartTimer()
        {
            StateMachine.ChangeState(WaveSpawnerState.WaitingForNextWave);
        }

        public override void Dispose()
        {
            Events.Wave.OnWaveTimerClicked.Subscribe(StartTimer, false);
        }

        public class Factory : PlaceholderFactory<WaitingForStart_WaveSpawnerState>
        {
        }
    }
}
