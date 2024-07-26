using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public GameObject player;
    public Transform respawnPoint;

    [Header("Variables")]
    public int points = 0;
    public int livesLeft;
    public int livesMax = 3;

    [Header("UI References")]
    public GameObject panelInGame;
    public GameObject panelGameOver;
    public TextMeshProUGUI txtPoints;
    public TextMeshProUGUI txtLives, txtBreath, txtResult;
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        livesLeft = livesMax;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.inGame:
                panelGameOver.SetActive(false);
                panelInGame.SetActive(true);

                txtPoints.text = (points + livesLeft * 10).ToString();
                txtLives.text = livesLeft.ToString();

                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

                txtBreath.text = TimeToString(player.breathCurrent);

                if (livesLeft <= 0)
                {
                    Lose();
                }
                
                if (points >= 10)
                {
                    AddLife();
                }

                break;
            case GameState.gameOver:
                panelGameOver.SetActive(true);
                panelInGame.SetActive(false);

                break;
        }
    }

    public void AddLife()
    {
        livesLeft += 1;
        points -= 10;
    }

    public string TimeToString(float time)
    {
        float minutes = time / 60;
        float seconds = time % 60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RespawnPlayer()
    {
        Instantiate(player, respawnPoint);
    }

    public void Win()
    {
        state = GameState.gameOver;
        txtResult.text = "Victory!";
    }
    
    public void Lose()
    {
        state = GameState.gameOver;
        txtResult.text = "Defeat!";
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}

public enum GameState
{
    inGame,
    gameOver
}
