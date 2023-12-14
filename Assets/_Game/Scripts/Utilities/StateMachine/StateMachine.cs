using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AmazingTowerDefenseGame.Utilities.StateMachine
{
    public abstract class StateMachine<TStateEnum> : IStateMachine<TStateEnum>, ITickable where TStateEnum : struct
    {
        public StateMachine()
        {

        }

        protected IState CurrentState { get; private set; }

        public virtual void ChangeState(IState newState)
        {
            if (CurrentState == null || !CurrentState.Equals(newState))
            {
                CurrentState?.Dispose();
                Debug.Log("CurrentState disposed: " + CurrentState?.GetType() ?? string.Empty);

                CurrentState = newState;
                Debug.Log("CurrentState changed: " + CurrentState?.GetType() ?? string.Empty);

                CurrentState?.Start();
                Debug.Log("CurrentState Started: " + CurrentState?.GetType() ?? string.Empty);
            }
        }

        public virtual void Tick()
        {
            return;
        }

        //public IState GetCurrentState()
        //{
        //    return currentState;
        //}
    }
}
