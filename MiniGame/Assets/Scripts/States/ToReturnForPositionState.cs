using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stt
{
    public class ToReturnForPositionState : IState<NPC>
    {
        private static ToReturnForPositionState instance;
        private Vector3 target;

        private ToReturnForPositionState() { }

        public static ToReturnForPositionState Instance
        {
            get
            {
                if (instance == null)
                    instance = new ToReturnForPositionState();
                return instance;
            }
        }

        public void Enter(NPC npc)
        {
            target = npc.InitialPosition;
        }

        public void Execute(NPC npc)
        {
            var position = npc.transform.position;
            target = position - npc.InitialPosition;
            if (target.sqrMagnitude != 0)
            {
                npc.transform.Translate(target.normalized * (target.magnitude * 0.5f) * Time.deltaTime);
            }
            else
            {
                npc.StateMachine.ChangeState(DefaultState.Instance);
                npc.HandleMessage(new Message(npc, EnemiesManagerScript.Instance, "In position"));
            }
        }

        public void Exit(NPC npc)
        {
            throw new NotImplementedException();
        }

        public bool OnMessage(NPC npc, Message message)
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
