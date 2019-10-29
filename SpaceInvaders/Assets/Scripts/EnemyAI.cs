using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IWarrior
{
    private IListenerOfAttackAction gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        if (transform.position.y < -300)
            DataManager.Instance.Life = 0;

    }

    public void Attack()
    {
        int r = UnityEngine.Random.Range(0, 2000);
        if (r < 1)
            gameController.attackAction(transform, tag);
    }

}
