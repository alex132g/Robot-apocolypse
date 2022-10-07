using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    
    public bool playerDead;
    public bool GameIsPaused = false;

    public GameObject PauseUI;

    public Movement player;
    public GameObject Player;
    public MouseLook cam;


    //make player die
    void Start()
    {
        playerDead = false;
    }

    public void Endgame()
    {
        if(playerDead == false)
        {
          Debug.Log("Game Over");
          playerDead = true;
          Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}