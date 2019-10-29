using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stt
{
    class DefaultState : IState<NPC>
    {
        private static DefaultState instance = null;

        private DefaultState() {}

        public static DefaultState Instance
        {
            get
            {
                if (instance == null)
                    instance = new DefaultState();
                return instance;
            }
        }

        public void Enter(NPC npc)
        {}

        public void Execute(NPC npc)
        {}

        public void Exit(NPC npc)
        {}

        public bool OnMessage(NPC npc, Message message)
        {
            if (message.Msg == "Fire")
            {
                if (npc.NameNpc == "Shooter")
                {
                    npc.StateMachine.ChangeState(ShooterState.Instance);
                    return true;
                }
                return false;
            }
            if (message.Msg == "Attack")
            {
                npc.StateMachine.ChangeState(SuicidalState.Instance);
                npc.HandleMessage(message);
            }

            return false;
        }
    }
}
