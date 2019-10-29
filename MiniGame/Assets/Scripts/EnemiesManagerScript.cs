using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManagerScript : MonoBehaviour, 
                                    IAdvertiser
{
    public float limitLeft, limitRight;
    public float vel;
    public NPC []enemies;
    private int dir;
    private static EnemiesManagerScript instance;

    private EnemiesManagerScript() { }

    public static EnemiesManagerScript Instance
    {
        get
        {
            if (!instance)
            {
                var temp = FindObjectOfType(typeof(EnemiesManagerScript)) as GameObject;

                if (instance)
                    instance = temp.GetComponent<EnemiesManagerScript>();
                else
                {
                    GameObject go = new GameObject("EnemiesManager");
                    DontDestroyOnLoad(go);

                    go.AddComponent<EnemiesManagerScript>();
                    instance = go.GetComponent<EnemiesManagerScript>();
                }
            }

            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dir = -1;
        enemies = FindObjectsOfType<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }

    public bool HandleMessage(Message message)
    {
        return false;
    }

    private void move()
    {
        transform.Translate(Vector2.right * dir * vel * Time.deltaTime);

        if (transform.position.x <= limitLeft || 
            transform.position.x >= limitRight  )
            dir *= -1;
    }

    private void fire()
    {
        int r = UnityEngine.Random.Range(0, 1000);
        if (r < 100 && r % 2 == 0)
        {
            int index = UnityEngine.Random.Range(9, 18);
            NPC npc = enemies[index];
            npc.HandleMessage(new Message(this, npc, "Fire"));
        }
    }
}
