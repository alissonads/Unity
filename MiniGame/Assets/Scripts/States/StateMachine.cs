using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stt
{
    public class StateMachine<GNPC>
    {
        private GNPC myOwner;
        private IState<GNPC> currentState;
        private IState<GNPC> previousState;
        private IState<GNPC> globalState;

        public StateMachine(GNPC owner)
        {
            myOwner = owner;
        }

        public StateMachine(StateMachine<GNPC> other)
        {
            myOwner = other.myOwner;
            currentState = other.currentState;
            previousState = other.previousState;
            globalState = other.globalState;
        }

        public StateMachine<GNPC> Clone()
        {
            var newStateMachine = new StateMachine<GNPC>(myOwner);
            newStateMachine.currentState = currentState;
            newStateMachine.previousState = previousState;
            newStateMachine.globalState = globalState;

            return newStateMachine;
        }

        public GNPC MyOwner
        {
            set { myOwner = value; }
            get { return myOwner; }
        }

        public IState<GNPC> CurrentState
        {
            set { currentState = value; }
            get { return currentState; }
        }

        public IState<GNPC> PreviousState
        {
            set { previousState = value; }
            get { return previousState; }
        }

        public IState<GNPC> GlobalState
        {
            set { globalState = value; }
            get { return globalState; }
        }

        public StateMachine<GNPC> Update()
        {
            if (globalState != null)
                globalState.Execute(myOwner);

            if (currentState != null)
                currentState.Execute(myOwner);

            return this;
        }

        public StateMachine<GNPC> ChangeState(IState<GNPC> newState)
        {
            if (previousState == null && currentState == null)
            {
                previousState = newState;
                currentState = newState;
                currentState.Enter(myOwner);
                return this;
            }

            previousState = currentState;

            currentState.Exit(myOwner);
            currentState = newState;
            currentState.Enter(myOwner);

            return this;
        }

        public StateMachine<GNPC> RevertToPreviousState()
        {
            return ChangeState(previousState);
        }

        public bool HandleMessage(Message message)
        {
            return (currentState != null && currentState.OnMessage(myOwner, message) ||
                    globalState  != null && globalState.OnMessage(myOwner, message));
        }
    }
}
