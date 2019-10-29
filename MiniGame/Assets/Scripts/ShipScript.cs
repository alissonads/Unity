using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour, 
                          IWarrior, 
                          IExplorer, 
                          ITarget,
                          IWarriorObservable
{
    public float vel;
    public float maxTime;
    public float limitLeft;
    public float limitRight;
    public Transform spawn;

    private List<IListenerOfAttackAction> listenersAttack = new List<IListenerOfAttackAction>();
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        addListenerOfAttackAction(FindObjectOfType<GeneratorObjectsScript>());
        addListenerOfAttackAction(FindObjectOfType<SoundEfectManager>());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Move();
        Attack();
    }

    public void Attack()
    {
        if (time >= maxTime && 
            Input.GetKeyDown(KeyCode.Space))
        {
            notifyListenerOfAttackAction();
            time = 0.0f;
        }
    }

    public void Hit(int damage = 0)
    {
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * x * vel * Time.deltaTime);

        Vector3 temp = transform.position;
        if (temp.x > limitRight)
            temp.x = limitRight;
        else if (temp.x < limitLeft)
            temp.x = limitLeft;

        transform.position = temp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    }

    public void notifyListenerOfAttackAction()
    {
        foreach (var listener in listenersAttack)
        {
            listener.AttackAction(spawn, tag);
        }
    }

    public void addListenerOfAttackAction(IListenerOfAttackAction listener)
    {
        listenersAttack.Add(listener);
    }

    public void removeListenerOfAttackAction(IListenerOfAttackAction listener)
    {
        listenersAttack.Remove(listener);
    }
}
