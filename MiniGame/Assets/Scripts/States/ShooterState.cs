using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stt
{
    class ShooterState : IState<NPC>
    {
        private static ShooterState instance;
        private ShooterScript shooter;

        private ShooterState() { }

        public static ShooterState Instance
        {
            get
            {
                if (instance == null)
                    instance = new ShooterState();
                return instance;
            }
        }

        public void Enter(NPC npc)
        {
            if (npc is ShooterScript)
                shooter = npc as ShooterScript;
        }

        public void Execute(NPC npc)
        {
            shooter.notifyListenerOfAttackAction();
            npc.StateMachine.ChangeState(DefaultState.Instance);
        }

        public void Exit(NPC npc)
        {
            shooter = null;
        }

        public bool OnMessage(NPC npc, Message message)
        {
            return false;
        }
    }
}
