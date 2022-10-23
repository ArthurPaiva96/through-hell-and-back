using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverImage;

    private Player player;

    private void Start()
    {
        this.player = GameObject.FindObjectOfType<Player>();
    }
    public void EndGame()
    {
        this.ChangeGameState(0, true);
        this.gameOverImage.SetActive(true);
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.ChangeGameState(1, false);
        this.player.Restart();
        destroyAllObstacles();
    }

    private static void destroyAllObstacles()
    {
        //TODO
    }

    private void ChangeGameState(int time, bool gameOverScreen)
    {
        Time.timeScale = time;
        this.gameOverImage.SetActive(gameOverScreen);
    }
}