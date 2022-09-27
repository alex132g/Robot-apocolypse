using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quester : MonoBehaviour
{
    public GameManager manager;
    public Quests quest;
    public QuestObjects questObj;
    public MouseLook mouseLook;

    public Transform playerTrans;
    public Transform questerTrans;
    
    public GameObject QuestUI;
    
    public Text descriptionTxt;
    public Text GoldTxt;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTrans.transform.position, questerTrans.transform.position) < 5 && quest.isActive == false)
        {
            QuestUI.SetActive(true);
            descriptionTxt.text = quest.description;
            GoldTxt.text = quest.goldReward.ToString();
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
        }else
        {
            QuestUI.SetActive(false);

              if(manager.GameIsPaused == false)
              {
                Cursor.lockState = CursorLockMode.Locked;
              }

            mouseLook.enabled = true;
        }
    }

    public void AcceptQuest()
    {
        QuestUI.SetActive(false);

            if(manager.GameIsPaused == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

        mouseLook.enabled = true;
        quest.isActive = true;
        questObj.quest = quest;
    }
}
