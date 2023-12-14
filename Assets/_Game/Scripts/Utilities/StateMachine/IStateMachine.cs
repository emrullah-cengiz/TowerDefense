using System;

namespace AmazingTowerDefenseGame.Utilities.StateMachine
{
    public interface IStateMachine<TStateEnum> where TStateEnum : struct
    {
        void ChangeState(IState state);
    }
}
