using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private DataManager dataManager;
    private float transitionTime;

    public Text []texts;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = DataManager.Instance;
        transitionTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        toManagerScene();
    }

    private void toManagerScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("SpaceInvaders");
        }
        else if (SceneManager.GetActiveScene().name == "SpaceInvaders")
        {
            if (dataManager.Life == 0 || dataManager.TotalEnemies == 0)
                transitionTime += Time.deltaTime;

            if (dataManager.Life == 0)
                texts[0].text = "INVADED SPACE";

            if (transitionTime >= 2.0f)
                SceneManager.LoadScene("GameOver");
        }
        else
        {
            if (texts.Length > 0)
            {
                if (dataManager.Shots > 0 && dataManager.Life > 0)
                {
                    float bonus = ((float)dataManager.Successes / dataManager.Shots) * 0.2f;
                    if ((dataManager.Time % 60) <= 45)
                        bonus += 0.1f;
                    if (dataManager.Life == 100)
                        bonus += 0.1f;
                    dataManager.Bonus = dataManager.Score * bonus;
                }

                texts[0].text = dataManager.TextTime;
                texts[1].text = dataManager.Shots.ToString();
                texts[2].text = dataManager.Successes.ToString();
                texts[3].text = ((int)dataManager.Bonus).ToString();
                texts[4].text = (dataManager.Score + (int)dataManager.Bonus).ToString();
            }
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
