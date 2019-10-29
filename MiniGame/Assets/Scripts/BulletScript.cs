using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletDirection
{
    UP,
    DOWN
}

public class BulletScript : MonoBehaviour, 
                            IExplorer,
                            ICollisionObservable
{
    public float limitUp, limitDown;
    public float velocity = 600;
    private BulletDirection direction;

    private List<IListenerOfActionOfCollision> listeners = new List<IListenerOfActionOfCollision>();

    public BulletDirection Direction
    {
        get { return direction; }
        set
        {
            direction = value;
            if (direction == BulletDirection.DOWN)
            {
                transform.Rotate(0, 0, 180);
                velocity = 200;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //direction = BulletDirection.UP;
        addListenerOfActionOfCollision(FindObjectOfType<SoundEfectManager>());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
        if (transform.position.y >= limitUp ||
            transform.position.y <= limitDown)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        notifyListenerOfActionOfCollision(other.gameObject);
    }

    public void addListenerOfActionOfCollision(IListenerOfActionOfCollision listener)
    {
        listeners.Add(listener);
    }

    public void removeListenerOfActionOfCollision(IListenerOfActionOfCollision listener)
    {
        listeners.Remove(listener);
    }

    public void notifyListenerOfActionOfCollision(GameObject param)
    {
        foreach (var listener in listeners)
        {
            listener.CollisionAction(this, param);
        }
    }
}
