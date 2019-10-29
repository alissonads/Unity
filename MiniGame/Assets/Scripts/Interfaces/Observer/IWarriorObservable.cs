public interface IWarriorObservable
{
    void addListenerOfAttackAction(IListenerOfAttackAction listener);
    void removeListenerOfAttackAction(IListenerOfAttackAction listener);
    void notifyListenerOfAttackAction();
}
