using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionFire
{
    UP,
    DOWN
}

public class FireScript : MonoBehaviour, 
                          IActor, 
                          IListenerOfAttackAction,
                          ICollisionObservable
{
    public float limitUp, limitDown;

    private float vel = 600;
    private DirectionFire direction;

    private IListenerOfActionOfCollision listener;
    private GameObject otherObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public DirectionFire Direction
    {
        get { return direction; }
        set
        {
            direction = value;
            if (direction == DirectionFire.DOWN)
            {
                vel = 200.0f;
                transform.Rotate(new Vector3(0, 0, -180));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        otherObj = other.gameObject;
        notifyListenerOfActionOfCollision();
        if (direction == DirectionFire.UP)
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
            }
    }

    public void Move()
    {
        transform.Translate(Vector2.up * vel * Time.deltaTime);
        if (transform.position.y >= limitUp || transform.position.y <= limitDown)
            Destroy(gameObject);
    }

    public void attackAction(params object[] events)
    {
        string tag = events[0] as string;
        if (tag == "Enemy")
            Direction = DirectionFire.DOWN;
        else
            Direction = DirectionFire.UP;
    }

    public void addListenerOfActionOfCollision(IListenerOfActionOfCollision listener)
    {
        this.listener = listener;
    }

    public void removeListenerOfActionOfCollision(IListenerOfActionOfCollision listener)
    {
        this.listener = null;
    }

    public void notifyListenerOfActionOfCollision()
    {
        listener.collisionAction(gameObject, otherObj, direction == DirectionFire.UP);
    }
}
