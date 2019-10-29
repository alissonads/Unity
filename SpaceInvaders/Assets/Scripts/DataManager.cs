using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    private int life;
    private int score;
    private string textTime;
    private float time;
    private float bonus;
    private int totalEnemies;
    private int shots;
    private int successes;

    private DataManager() { }

    public static DataManager Instance
    {
        get
        {
            if (!instance)
            {
                var temp = FindObjectOfType(typeof(DataManager)) as GameObject;

                if (instance)
                {
                    instance = temp.GetComponent<DataManager>();
                }
                else
                {
                    GameObject go = new GameObject("DataManager");
                    DontDestroyOnLoad(go);

                    go.AddComponent<DataManager>();
                    instance = go.GetComponent<DataManager>();
                }
            }

            return instance;
        }
    }

    public int Life
    {
        set
        {
            life = value;
            life = (life < 0) ? 0 : life;
        }
        get { return life; }
    }

    public int Score
    {
        set { score = value; }
        get { return score; }
    }
    
    public string TextTime
    {
        set { textTime = value; }
        get { return textTime; }
    }

    public float Time
    {
        set { time = value; }
        get { return time; }
    }

    public float Bonus
    {
        set { bonus = value; }
        get { return bonus; }
    }

    public int TotalEnemies
    {
        set { totalEnemies = value; }
        get { return totalEnemies; }
    }

    public int Shots
    {
        set { shots = value; }
        get { return shots; }
    }

    public int Successes
    {
        set { successes = value; }
        get { return successes; }
    }

    void Start()
    {
        life = 100;
    }

    public void Reset()
    {
        life = 100;
        score = 0;
        textTime = "00:00";
        time = 0.0f;
        bonus = 0.0f;
        totalEnemies = 0;
        shots = 0;
        successes = 0;
    }
}
