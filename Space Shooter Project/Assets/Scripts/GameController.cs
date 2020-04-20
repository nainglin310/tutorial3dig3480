using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public int score;

    public Text restartText;
    public Text gameOverText;
    public bool gameOver;
    private bool restart;
    public Text winText;
    public AudioSource musicSource;
    public AudioClip victoryMusic;
    public AudioClip defeatMusic;


    void Start()
    {
        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Main_");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)

            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 300)
        {
            restartText.text = "Press 'X' to Restart";
            winText.text = "You win! GAME CREATED BY NAING LIN";
            musicSource.clip = victoryMusic;
            musicSource.Play();
            gameOver = false;
            restart = true;
        }
    }

    public void GameOver()
    {
        if (gameOver == true)
        {
            restartText.text = "Press 'X' to Restart";
            restart = true;

        }
        gameOverText.text = "Game Over! GAME CREATED BY NAING LIN";
        musicSource.clip = defeatMusic;
        musicSource.Play();

    }
}