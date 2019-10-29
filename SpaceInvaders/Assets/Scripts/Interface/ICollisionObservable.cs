using System;

public interface ICollisionObservable
{
    void addListenerOfActionOfCollision(IListenerOfActionOfCollision listener);
    void removeListenerOfActionOfCollision(IListenerOfActionOfCollision listener);
    void notifyListenerOfActionOfCollision();
}
