using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quester : MonoBehaviour, IDataPersistence
{
    public MouseLook mouseLook;

    public Transform playerTrans;
    public Transform questerTrans;
    
    public GameObject QuestUI;
    public GameObject Quest_questUI;
    
    public Text descriptionTxt;
    public Text GoldTxt;

    public bool QuestUIisActive;

    public string[] allTexts;

    public void SaveData(GameData data)
    {
        QuestUIisActive = data.QuestUIisActive;
    }

    public void LoadData(GameData data)
    {
       data.QuestUIisActive = QuestUIisActive;
    }

    void Start()
    {
        if(Quest_questUI.activeInHierarchy)
        {
            QuestUIisActive = true;
        }else
        {
            QuestUIisActive = false;
        }

        TextSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(QuestUIisActive == true) 
        {
            Quest_questUI.SetActive(true);
        }

        if(QuestUIisActive == false)
        {
            Quest_questUI.SetActive(false);
        }

        if(Vector3.Distance(playerTrans.transform.position, questerTrans.transform.position) < 5 && FindObjectOfType<Quest>().isActive == false && QuestUIisActive == false)
        {
            QuestUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
        }else
        {
            QuestUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;  
            mouseLook.enabled = true;
        }
    }

    public void Accept()
    {
        QuestUIisActive = true;
        Quest_questUI.SetActive(true);
        FindObjectOfType<Quest>().isActive = true;
    }

    public void TextSetup()
    {
        descriptionTxt.text = allTexts[0].ToString();
        GoldTxt.text = allTexts[1].ToString();
    }

  
}
