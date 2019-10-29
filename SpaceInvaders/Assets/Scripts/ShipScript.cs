using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour, IActor, IWarrior
{
    public float vel = 30;
    public Transform spawn;
    public float maxTime;

    private Animator anim;
    private float time = 0.0f;

    private IListenerOfActionOfCollision listenerCollision;
    private IListenerOfAttackAction listenerAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        var gameController = FindObjectOfType<GameControllerScript>();
        listenerCollision = gameController;
        listenerAttack = gameController;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        Move();
        Attack();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
            listenerCollision.collisionAction(gameObject, other.gameObject);
    }

    /* No fim da animação ativa o trigger para retornar 
       a posição inicial da animação */
    private void endAnim()
    {
        anim.SetTrigger("return");
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        int val = (x > 0) ? 1 : (x < 0) ? 2 : 0;

        anim.SetInteger("move", val);

        transform.Translate(x * vel * Time.deltaTime, 0, 0);
    }

    public void Attack()
    {
        if (time >= maxTime && Input.GetKeyDown(KeyCode.Space))
        {
            listenerAttack.attackAction(spawn, tag);
            time = 0.0f;
        }
    }
}
