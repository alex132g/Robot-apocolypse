using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool playerDead;

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