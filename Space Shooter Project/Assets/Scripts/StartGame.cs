﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public float timeLeft;
    public Text startText; // used for showing countdown from 3, 2, 1 
    public bool gameOver;


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft <= 0)
        {
            gameOver = true;
        }
    }
}