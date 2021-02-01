using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    Text timerText;
    public Text Status;
    public GameObject Launcher;
    public AudioSource WinBG;
    public AudioSource LoseBG;
    public GameObject BGMusic;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        Status.text = "";
        timerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0)
        {
            timerText.text = "Timer: " + Mathf.Round(timer);
        }

        if (timer > 10)
        {
            
            Destroy(BGMusic.gameObject);
            //WinBG.Play();
            Destroy(Launcher);
            Time.timeScale = 0;
            
            
            Status.text = "You Win! \nPress R to Restart \n Or Escape to Quit";
            

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        

            if (Time.timeScale == 0 && timer < 10)
            {
                Destroy(BGMusic.gameObject);
                //LoseBG.Play();
                Destroy(Launcher);
                Status.text = "You Lose! \nPress R to Restart \n Or Escape to Quit";
            
            
            }
    }
}
