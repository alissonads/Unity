using UnityEngine;

public interface ICollisionObservable
{
    void addListenerOfActionOfCollision(IListenerOfActionOfCollision listener);
    void removeListenerOfActionOfCollision(IListenerOfActionOfCollision listener);
    void notifyListenerOfActionOfCollision(GameObject param);
}
