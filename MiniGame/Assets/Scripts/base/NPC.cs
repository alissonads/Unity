using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, 
                            IAdvertiser,
                            IWarrior
{
    protected stt.StateMachine<NPC> stateMachine;
    protected string nameNpc = "";
    protected Vector3 initialPosition;

    public stt.StateMachine<NPC> StateMachine
    {
        set { stateMachine = value; }
        get { return stateMachine; }
    }

    public string NameNpc
    {
        get { return nameNpc; }
        set { nameNpc = value; }
    }

    public Vector3 InitialPosition
    {
        get { return initialPosition; }
        set
        {
            initialPosition = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        stateMachine = new stt.StateMachine<NPC>(this);
        stateMachine.CurrentState = stt.DefaultState.Instance;
        stateMachine.GlobalState = stt.DefaultState.Instance;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        stateMachine.Update();
    }

    public bool HandleMessage(Message message)
    {
        return stateMachine.HandleMessage(message);
    }

    public virtual void Attack()
    {
        throw new NotImplementedException();
    }
}

