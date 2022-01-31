using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
      public Enemy[] enemies;

    public Beaver beaver;

    public Transform logs;

    public int score { get; private set; }

    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if(this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform logs in this.logs)
        {
            logs.gameObject.SetActive(true);
        }

       ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < this.enemies.Length; i++)
        {
            this.enemies[i].gameObject.SetActive(true);
        }

         this.beaver.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < this.enemies.Length; i++)
        {
            this.enemies[i].gameObject.SetActive(false);
        }

         this.beaver.gameObject.SetActive(false);
    }

    private void SetScore (int score)
    {
        this.score = score;
    }

    private void SetLives (int lives)
    {
        this.lives = lives;
    }

    public void EnemyBeaten (Enemy enemy)
    {
        SetScore(this.score + enemy.points);
    }

    public void BeaverBeaten ()
    {
        this.beaver.gameObject.SetActive(false);

        SetLives(this.lives -1);

        if(this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }
}

