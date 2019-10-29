using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObjectsScript : MonoBehaviour, 
                                      IListenerOfAttackAction, 
                                      IListenerOfActionOfCollision
{
    public GameObject playerProjectile;
    public GameObject enemyProjectile;
    public GameObject explosioObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackAction(params object[] events)
    {
        var spawn = events[0] as Transform;
        var otherTag = events[1] as string;
        var bullet = (otherTag == "Player") ? playerProjectile : enemyProjectile;
        var temp = Instantiate(bullet, spawn.position, spawn.rotation);

        if (otherTag == "Enemy")
        {
            var bulletScript = temp.GetComponent<BulletScript>();
            bulletScript.Direction = BulletDirection.DOWN;
        }
        else
        {
            var bulletScript = temp.GetComponent<BulletScript>();
            bulletScript.Direction = BulletDirection.UP;
        }
        
        var observable = temp.GetComponent<ICollisionObservable>();
        observable.addListenerOfActionOfCollision(this);
    }

    public void CollisionAction(params object[] events)
    {
        var obj1 = events[0] as BulletScript;
        var obj2 = events[1] as GameObject;

        if (obj1.Direction == BulletDirection.DOWN)
        {
            if (obj2.tag == "Player")
                onCollision(obj1.gameObject, obj2);
        }
        else
        {
            if (obj2.tag == "Enemy")
                onCollision(obj1.gameObject, obj2);
        }
    }

    private void createExplosion(Transform transform)
    {
        Instantiate(explosioObject, transform.position, transform.rotation);
    }

    private void onCollision(GameObject obj1, GameObject obj2)
    {
        Destroy(obj1);
        Destroy(obj2);
        createExplosion(obj2.transform);
    }
}
