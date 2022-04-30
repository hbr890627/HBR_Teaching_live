using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogError("more than one GameManager");
        }
    }

    public Text gameOverText;
    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
        // 暫停遊戲

        // while (!Input.GetKeyDown(KeyCode.R))
        //     Debug.Log("wait for restart");

        // 跳回主選單
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
