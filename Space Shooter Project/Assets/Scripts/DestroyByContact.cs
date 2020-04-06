using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameContoller;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameContoller = gameControllerObject.GetComponent <GameController>();
        }
        if (gameContoller == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            return;
        }
        
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameContoller.GameOver();
        }
        gameContoller.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
