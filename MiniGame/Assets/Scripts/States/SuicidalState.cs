using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stt
{
    class SuicidalState : IState<NPC>
    {
        private static SuicidalState instance;

        private SuicidalState() { }

        public static SuicidalState Instance
        {
            get
            {
                if (instance == null)
                    instance = new SuicidalState();
                return instance;
            }
        }

        public void Enter(NPC npc)
        {
            
        }

        public void Execute(NPC npc)
        {
            npc.Attack();
        }

        public void Exit(NPC npc)
        {
            
        }

        public bool OnMessage(NPC npc, Message message)
        {
            return false;
        }
    }
}
