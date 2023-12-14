using System;

namespace AmazingTowerDefenseGame.Utilities.StateMachine
{
    public interface IState
    {
        void Start();

        void Tick();

        void Dispose();
    }
}
