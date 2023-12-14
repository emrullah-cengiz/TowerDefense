using AmazingTowerDefenseGame;
using AmazingTowerDefenseGame.Utilities.StateMachine;
using AmazingTowerDefenseGame.Waves.StateMachine;
using System;
using UnityEngine;
using Zenject;

public class WavesInstaller : MonoInstaller
{
    [SerializeField] private WaveSpawnerView waveSpawnerView;

    public override void InstallBindings()
    {
        Container.Bind<WaveSettings>().FromNewScriptableObjectResource(GlobalVariables.SETTINGS_RESOURCE_PATH + "/" + nameof(WaveSettings))
                                      .AsSingle();

        InstallWaveSpawner();

        InstallStateMachine();

    }

    private void InstallWaveSpawner()
    {
        Container.BindInterfacesAndSelfTo<WaveSpawner>().AsSingle();
        Container.Bind<WaveSpawnerModel>().AsSingle();
        Container.Bind<WaveSpawnerView>().FromMethod(() => waveSpawnerView);

        Container.BindMemoryPool<Wave, Wave.Pool>();
    }

    private void InstallStateMachine()
    {
        Container.BindInterfacesAndSelfTo<WaveSpawnerStateMachine>().AsSingle();

        Container.Bind<WaitingForStart_WaveSpawnerState>().AsSingle();
        Container.Bind<WaitingForNextWave_WaveSpawnerState>().AsSingle();

        Container.BindFactory<WaitingForStart_WaveSpawnerState, WaitingForStart_WaveSpawnerState.Factory>().WhenInjectedInto<WaveSpawnerStateMachine>();
        Container.BindFactory<WaitingForNextWave_WaveSpawnerState, WaitingForNextWave_WaveSpawnerState.Factory>().WhenInjectedInto<WaveSpawnerStateMachine>();
    }
}