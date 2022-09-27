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

    //Pause Menu
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(GameIsPaused == true)
            {
               Resume();
            }else
            {
               Pause();
            }

        }
       
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
        cam.enabled = true;
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        player.enabled = true;
        cam.enabled = true;
    }
    
    //Save And Load Game Files
    public void SavePlayer()
    {
        SaveSystem.SaveData(player);
    }

    public void LoadPlayer()
    {
        Data data = SaveSystem.LoadData();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}