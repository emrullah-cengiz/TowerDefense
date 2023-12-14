using System;

namespace AmazingTowerDefenseGame.Utilities.StateMachine
{
    public abstract class State<TStateMachine, TStateEnum> : IState where TStateMachine : IStateMachine<TStateEnum>
                                                                    where TStateEnum : struct
    {
        protected readonly TStateMachine StateMachine;

        public State(TStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public abstract void Start();

        public virtual void Tick() { }

        public abstract void Dispose();
    }
}
