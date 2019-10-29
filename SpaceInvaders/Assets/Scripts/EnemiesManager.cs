using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour, IActor
{
    public float limitLeft, limitRight;
    public float vel;
    private int dir = -1;
    private bool down = false;
    private float acceleration = 1.0f;

    void Start()
    {
        //DataManager.Instance.TotalEnemies = transform.childCount;
        //transform.GetChild(0).SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void stateChange()
    {
        dir *= -1;
        down = true;

        if (dir < 0 && acceleration < 4.0f)
            acceleration += 0.35f;
    }

    public void Move()
    {
        if (down)
        {
            transform.Translate(Vector2.down * 600 * Time.deltaTime);
            down = false;
        }

        transform.Translate(Vector2.right * dir * vel * Time.deltaTime * acceleration);

        if (transform.position.x <= limitLeft && dir == -1)
            stateChange();
        else if (transform.position.x >= limitRight && dir == 1)
            stateChange();
    }
}
