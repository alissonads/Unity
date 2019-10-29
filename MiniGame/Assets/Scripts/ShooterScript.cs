using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : NPC, IWarriorObservable
{
    private List<IListenerOfAttackAction> listenersAttack = new List<IListenerOfAttackAction>();

    protected override void Start()
    {
        base.Start();
        nameNpc = "Shooter";
        addListenerOfAttackAction(FindObjectOfType<GeneratorObjectsScript>());
        addListenerOfAttackAction(FindObjectOfType<SoundEfectManager>());
    }

    protected override void Update()
    {
        base.Update();
    }

    public void addListenerOfAttackAction(IListenerOfAttackAction listener)
    {
        listenersAttack.Add(listener);
    }

    public void notifyListenerOfAttackAction()
    {
        foreach (var listener in listenersAttack)
        {
            listener.AttackAction(transform, tag);
        }
    }

    public void removeListenerOfAttackAction(IListenerOfAttackAction listener)
    {
        listenersAttack.Remove(listener);
    }
}

