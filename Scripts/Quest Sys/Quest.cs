using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour, IDataPersistence
{
    
    public Text progressText;

    public GameObject checkMark;

    public bool isActive = false;

    public int currentAmount;
    public int reqierdAmount;

    [HideInInspector] public Quest[] allQuests;

    public void LoadData(GameData data)
    {
        currentAmount = data.currentAmount;
        isActive = data.isActive;
    }

    public void SaveData(GameData data)
    {
        data.currentAmount = currentAmount;
        data.isActive = isActive;
    }
    
    public void Start()
    {
        // sets up the UI
        progressText.text = currentAmount.ToString() + "/" + reqierdAmount.ToString();

        // sets up the array of quests
        allQuests = FindObjectsOfType<Quest>();

    }

    void Update() {
        
         foreach (Quest quest in allQuests)
        {
            quest.progressText.text = quest.currentAmount.ToString() + "/" + quest.reqierdAmount.ToString();
        }

    }


    // adds the 1 to currentamount
    public void OnTriggerEnter(Collider collision) 
    {
        currentAmount += 1;

        if(currentAmount >= reqierdAmount)
        {
            FinishQuest();
        }
    }
    
    // destroys current gameObject
    public void OnTriggerExit(Collider col) 
    {
        currentAmount += 1;

        Destroy(gameObject);

       
    }


    // called when the quest is completed
    public void FinishQuest()
    {
        if(isActive == true && currentAmount >= reqierdAmount)
        {
            checkMark.SetActive(true);
            isActive = false;
            currentAmount = 0;

            progressText.text = reqierdAmount.ToString() + "/" + reqierdAmount.ToString();
        }
       
    }
}
