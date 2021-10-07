using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerLogic : MonoBehaviour
{
    public Slider timerSlider;

    public LevelReload levelReload;

    public float gameTime;

    private bool stopTimer;

    float timer = 0.00f;

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float time = gameTime - timer;

        if (time <= 0)
        {
            stopTimer = true;
            levelReload.ReloadLevel();
        }
        if (stopTimer == false)
        {
            timerSlider.value = time;
        }

        if (Input.GetButtonDown("Debug Reset"))
        {
            levelReload.ReloadLevel();
        }
    }
}
