using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class starfieldController : MonoBehaviour
{
    public float scrollSpeed;
    public GameController gameController;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    void Start()
    {

    }

    void Update()
    {
        if (gameController.score >= 300)
        {
            ps1.playbackSpeed = 100;
            ps2.playbackSpeed = 50;
        }

    }

}

