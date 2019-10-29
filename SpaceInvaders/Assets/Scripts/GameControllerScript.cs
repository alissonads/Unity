using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour, 
                                    IListenerOfAttackAction,
                                    IListenerOfActionOfCollision
{
    public GameObject fire;
    public GameObject explosion;
    public AudioClip []audioClips;
    public Text []texts;

    private AudioSource audioSource;
    private Slider plife;

    private DataManager dataManager;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        plife = FindObjectOfType<Slider>();
        dataManager = DataManager.Instance;

        var enemies = GameObject.Find("Enemies");
        dataManager.Reset();
        dataManager.TotalEnemies = enemies.transform.childCount;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeOfGame();
        updateScore();
        applyUI();
    }

    public void attackAction(params object[] events)
    {
        var _transform = events[0] as Transform;
        var temp = Instantiate(fire, _transform.position, _transform.rotation);

        temp.GetComponent<IListenerOfAttackAction>().attackAction((string)events[1]);
        temp.GetComponent<ICollisionObservable>().addListenerOfActionOfCollision(this);

        audioSource.PlayOneShot(audioClips[0], 1.0f);

        if ((string)events[1] == "Player")
            dataManager.Shots++;
    }

    public void collisionAction(params object[] events)
    {
        var objMain = events[0] as GameObject;

        if (objMain.tag == "Player")
        {
            var otherObj = events[1] as GameObject;
            dataManager.Life = 0;
            createExplosion(objMain);
            createExplosion(otherObj);
            Destroy(otherObj);
            Destroy(objMain);
        }
        else
        {
            var otherObj = events[1] as GameObject;
            var up = (bool)events[2];

            if (up && otherObj.tag == "Enemy")
            {
                createExplosion(objMain);
                Destroy(objMain);
                dataManager.Score += 20;
                dataManager.TotalEnemies--;
                dataManager.Successes++;
            }
            else if (otherObj.tag == "Player")
            {
                createExplosion(objMain);
                Destroy(objMain);
                if (dataManager.Life > 0)
                    dataManager.Life -= 20;

                if (dataManager.Life <= 0)
                {
                    createExplosion(otherObj);
                    Destroy(otherObj);
                }
            }
        }
    }

    private void createExplosion(GameObject obj)
    {
        Instantiate(explosion, obj.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(audioClips[1], 1.0f);
    }

    private void applyUI()
    {
        texts[0].text = dataManager.Life.ToString() + "%";
        texts[1].text = dataManager.Score.ToString();
        texts[2].text = dataManager.TextTime;
        plife.value = dataManager.Life;
    }

    private void timeOfGame()
    {
        if (dataManager.TotalEnemies > 0)
        {
            time += Time.deltaTime;
            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);

            if (minutes == 0 || minutes < 10)
                dataManager.TextTime = "0";
            dataManager.TextTime += minutes.ToString() + ":";

            if (seconds == 0 || seconds < 10)
                dataManager.TextTime += "0";
            dataManager.TextTime += seconds.ToString();

            dataManager.Time = time;
        }
    }

    private void updateScore()
    {
        
    }
}
