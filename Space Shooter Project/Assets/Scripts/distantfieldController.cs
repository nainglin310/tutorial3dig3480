using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class distantfieldController : MonoBehaviour
{
    private ParticleSystem ps;
    public float SliderValue = 1.0F;
    public GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (gameController.score >= 300)
        {
            var main = ps.main;
            main.simulationSpeed = SliderValue;
        }

    }

}
