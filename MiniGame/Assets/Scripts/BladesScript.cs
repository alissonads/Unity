using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesScript : NPC
{
    public float velocity;
    public Transform target;

    protected override void Start()
    {
        base.Start();
        nameNpc = "Blade";
    }

    public override void Attack()
    {
        var direction = (target.position - transform.position).normalized;
        transform.Translate(direction * velocity * Time.deltaTime);
    }
}
