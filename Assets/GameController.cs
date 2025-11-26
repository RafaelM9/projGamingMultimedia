using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
     public GameObject hazard;
     public Vector3 spawnValues;
     public int hazardCount = 10;

     public float spawnWait, waveWait, startWait;

     //to control UI
     public TextMeshProUGUI scoreText;
     public TextMeshProUGUI gameOverText;
     public TextMeshProUGUI restartText;

     int score; //to control score
     Boolean gameOver, restart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score=0;
        WriteScore();
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for(int i=0; i<hazardCount; i++)
            {
                Vector3  spawnPosition= new Vector3(UnityEngine.Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard,spawnPosition,spawnRotation);
                yield return new WaitForSeconds(spawnWait);

                if (gameOver)
                {
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press <R> to Restart";
                restart = true;
                break;
            }
        }
        
        
    }


    public void AddScore()
    {
        score = score +10;
        WriteScore();

    }

    void WriteScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        
        gameOver = true;
        gameOverText.text = "Game Over";

    }

    // Update is called once per frame
    void Update()
    {
        
        if(restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
