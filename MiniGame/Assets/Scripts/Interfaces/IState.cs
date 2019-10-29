namespace stt
{
    public interface IState<NPC>
    {
        void Enter(NPC npc);
        void Execute(NPC npc);
        void Exit(NPC npc);
        bool OnMessage(NPC npc, Message message);
    }
}
